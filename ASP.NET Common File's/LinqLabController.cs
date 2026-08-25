using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceRequestManagementSystem.API.Data;
using ServiceRequestManagementSystem.API.DTOs.Common;
using ServiceRequestManagementSystem.API.Enums;

namespace ServiceRequestManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api")]
    public class LinqLabController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LinqLabController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("users/total-requestors")]
        public async Task<ActionResult<ApiResponseDto<int>>> GetTotalRequestors()
        {
            var totalRequestors = await _context.Users
                .CountAsync(u => u.Role == UserRole.Requestor);

            return Ok(new ApiResponseDto<int>
            {
                Success = true,
                Message = "Total requestors count retrieved.",
                Data = totalRequestors
            });
        }

        [HttpGet("users/total-technicians")]
        public async Task<ActionResult<ApiResponseDto<int>>> GetTotalTechnicians()
        {
            var totalTechnicians = await _context.Users
                .CountAsync(u => u.Role == UserRole.Technician);

            return Ok(new ApiResponseDto<int>
            {
                Success = true,
                Message = "Total technicians count retrieved.",
                Data = totalTechnicians
            });
        }

        [HttpGet("requests/total-count")]
        public async Task<ActionResult<ApiResponseDto<int>>> GetTotalServiceRequests()
        {
            var totalRequests = await _context.ServiceRequests.CountAsync();

            return Ok(new ApiResponseDto<int>
            {
                Success = true,
                Message = "Total service requests count retrieved.",
                Data = totalRequests
            });
        }

        [HttpGet("requests/status-summary")]
        public async Task<ActionResult<ApiResponseDto<object>>> GetStatusCategorySummary()
        {
            var summary = await _context.ServiceRequests
                .Include(r => r.Status)
                .GroupBy(r => r.Status != null ? r.Status.StatusName : "Unknown")
                .Select(g => new
                {
                    Status = g.Key,
                    TotalTasks = g.Count()
                })
                .ToListAsync();

            return Ok(new ApiResponseDto<object>
            {
                Success = true,
                Message = "Requests count by status category retrieved.",
                Data = summary
            });
        }

        [HttpGet("requests/priority-summary")]
        public async Task<ActionResult<ApiResponseDto<object>>> GetPriorityWiseCount()
        {
            var prioritySummary = await _context.ServiceRequests
                .GroupBy(r => r.Priority)
                .Select(g => new
                {
                    Priority = g.Key.ToString(),
                    TotalTasks = g.Count()
                })
                .ToListAsync();

            return Ok(new ApiResponseDto<object>
            {
                Success = true,
                Message = "Priority-wise request count retrieved.",
                Data = prioritySummary
            });
        }

        [HttpGet("technicians/workload")]
        public async Task<ActionResult<ApiResponseDto<object>>> GetTechnicianWorkload()
        {
            var workload = await _context.ServiceRequests
                .Where(r => r.AssigneeUserId != null)
                .GroupBy(r => r.Assignee != null ? r.Assignee.FullName : "Unassigned")
                .Select(g => new
                {
                    TechnicianName = g.Key,
                    AssignedRequests = g.Count()
                })
                .OrderByDescending(x => x.AssignedRequests)
                .ToListAsync();

            return Ok(new ApiResponseDto<object>
            {
                Success = true,
                Message = "Technician request workload count retrieved.",
                Data = workload
            });
        }

        [HttpGet("requestors/ticket-counts")]
        public async Task<ActionResult<ApiResponseDto<object>>> GetRequestorTicketCounts()
        {
            var requestorTasks = await _context.ServiceRequests
                .GroupBy(r => r.Requester != null ? r.Requester.FullName : "Unknown")
                .Select(g => new
                {
                    RequestorName = g.Key,
                    TotalRequests = g.Count()
                })
                .OrderByDescending(x => x.TotalRequests)
                .ToListAsync();

            return Ok(new ApiResponseDto<object>
            {
                Success = true,
                Message = "Requests created by each requestor retrieved.",
                Data = requestorTasks
            });
        }

        [HttpGet("technicians/top-performers")]
        public async Task<ActionResult<ApiResponseDto<object>>> GetTopTechniciansResolved()
        {
            var topTechnicians = await _context.ServiceRequests
                .Where(r => r.AssigneeUserId != null && r.Status != null && (r.Status.StatusName == "Resolved" || r.Status.StatusName == "Closed"))
                .GroupBy(r => r.Assignee != null ? r.Assignee.FullName : "Unknown")
                .Select(g => new
                {
                    TechnicianName = g.Key,
                    ResolvedCount = g.Count()
                })
                .OrderByDescending(x => x.ResolvedCount)
                .Take(10)
                .ToListAsync();

            return Ok(new ApiResponseDto<object>
            {
                Success = true,
                Message = "Top technicians with highest resolution count retrieved.",
                Data = topTechnicians
            });
        }

        [HttpGet("technicians/workload-rankings")]
        public async Task<ActionResult<ApiResponseDto<object>>> GetTechniciansWorkloadRankings()
        {
            var bottomTechnicians = await _context.Users
                .Where(u => u.Role == UserRole.Technician)
                .Select(u => new
                {
                    TechnicianName = u.FullName,
                    TotalAssigned = _context.ServiceRequests.Count(r => r.AssigneeUserId == u.UserId),
                    ResolvedCount = _context.ServiceRequests.Count(r => r.AssigneeUserId == u.UserId && r.Status != null && r.Status.StatusName == "Resolved")
                })
                .OrderBy(x => x.ResolvedCount)
                .Take(10)
                .ToListAsync();

            return Ok(new ApiResponseDto<object>
            {
                Success = true,
                Message = "Technicians workload rankings retrieved.",
                Data = bottomTechnicians
            });
        }

        [HttpGet("requests/overdue")]
        public async Task<ActionResult<ApiResponseDto<object>>> GetOverdueRequests()
        {
            var cutoffDate = DateTime.UtcNow.AddDays(-2);

            var overdueTasks = await _context.ServiceRequests
                .Include(r => r.Requester)
                .Include(r => r.Assignee)
                .Include(r => r.Status)
                .Where(r => r.CreatedAt < cutoffDate && r.Status != null && r.Status.StatusName != "Resolved" && r.Status.StatusName != "Closed")
                .Select(r => new
                {
                    r.RequestId,
                    r.RequestNumber,
                    r.Title,
                    Requestor = r.Requester != null ? r.Requester.FullName : "Unknown",
                    Assignee = r.Assignee != null ? r.Assignee.FullName : "Unassigned",
                    Status = r.Status != null ? r.Status.StatusName : "Unknown",
                    r.CreatedAt,
                    DaysOverdue = (int)(DateTime.UtcNow - r.CreatedAt).TotalDays
                })
                .ToListAsync();

            return Ok(new ApiResponseDto<object>
            {
                Success = true,
                Message = "Overdue incomplete service requests retrieved.",
                Data = overdueTasks
            });
        }

        [HttpGet("requests/recent-updates")]
        public async Task<ActionResult<ApiResponseDto<object>>> GetRecentUpdates()
        {
            var startDate = DateTime.UtcNow.AddDays(-7);

            var recentRequests = await _context.ServiceRequests
                .Include(r => r.Requester)
                .Include(r => r.Assignee)
                .Where(r => r.UpdatedAt >= startDate)
                .Select(r => new
                {
                    r.RequestNumber,
                    r.Title,
                    Requestor = r.Requester != null ? r.Requester.FullName : "Unknown",
                    Assignee = r.Assignee != null ? r.Assignee.FullName : "Unassigned",
                    r.UpdatedAt
                })
                .OrderByDescending(r => r.UpdatedAt)
                .ToListAsync();

            return Ok(new ApiResponseDto<object>
            {
                Success = true,
                Message = "Requests updated within the last 7 days retrieved.",
                Data = recentRequests
            });
        }

        [HttpGet("requests/priority-distribution")]
        public async Task<ActionResult<ApiResponseDto<object>>> GetPriorityDistribution()
        {
            var priorityDistribution = await _context.ServiceRequests
                .GroupBy(r => r.Priority)
                .Select(g => new
                {
                    Priority = g.Key.ToString(),
                    TotalRequests = g.Count()
                })
                .OrderBy(x => x.Priority)
                .ToListAsync();

            return Ok(new ApiResponseDto<object>
            {
                Success = true,
                Message = "Request priority distribution retrieved.",
                Data = priorityDistribution
            });
        }

        [HttpGet("reports/monthly-completion")]
        public async Task<ActionResult<ApiResponseDto<object>>> GetMonthlyCompletionReport()
        {
            var monthlyCompletion = await _context.ServiceRequests
                .Where(r => r.Status != null && (r.Status.StatusName == "Resolved" || r.Status.StatusName == "Closed"))
                .GroupBy(r => new
                {
                    Year = r.UpdatedAt.Year,
                    Month = r.UpdatedAt.Month
                })
                .Select(g => new
                {
                    g.Key.Year,
                    g.Key.Month,
                    CompletedRequests = g.Count()
                })
                .OrderBy(x => x.Year)
                .ThenBy(x => x.Month)
                .ToListAsync();

            return Ok(new ApiResponseDto<object>
            {
                Success = true,
                Message = "Month-wise completed request count retrieved.",
                Data = monthlyCompletion
            });
        }

        [HttpGet("users/active-by-role")]
        public async Task<ActionResult<ApiResponseDto<object>>> GetActiveUsersByRole()
        {
            var activeUserCount = await _context.Users
                .Where(u => u.Status == UserStatus.Active)
                .GroupBy(u => u.Role.ToString())
                .Select(g => new
                {
                    RoleName = g.Key,
                    ActiveUsers = g.Count()
                })
                .OrderByDescending(x => x.ActiveUsers)
                .ToListAsync();

            return Ok(new ApiResponseDto<object>
            {
                Success = true,
                Message = "Role-wise active user count retrieved.",
                Data = activeUserCount
            });
        }

        [HttpGet("users/grouped-by-role")]
        public async Task<ActionResult<ApiResponseDto<object>>> GetUsersGroupedByRole()
        {
            var rolesWithUsers = await _context.Users
                .GroupBy(u => u.Role.ToString())
                .Select(g => new
                {
                    RoleName = g.Key,
                    Users = g.Select(u => u.FullName).ToList()
                })
                .ToListAsync();

            return Ok(new ApiResponseDto<object>
            {
                Success = true,
                Message = "Roles with assigned users list retrieved.",
                Data = rolesWithUsers
            });
        }

        [HttpGet("roles/multi-user-roles")]
        public async Task<ActionResult<ApiResponseDto<object>>> GetMultiUserRoles()
        {
            var result = await _context.Users
                .GroupBy(u => u.Role.ToString())
                .Select(g => new
                {
                    RoleName = g.Key,
                    TotalUsers = g.Count()
                })
                .Where(x => x.TotalUsers >= 1)
                .ToListAsync();

            return Ok(new ApiResponseDto<object>
            {
                Success = true,
                Message = "Roles having multiple users retrieved.",
                Data = result
            });
        }

        [HttpGet("roles/statistics")]
        public async Task<ActionResult<ApiResponseDto<object>>> GetRoleStatistics()
        {
            var stats = await _context.Users
                .GroupBy(u => u.Role.ToString())
                .Select(g => new
                {
                    RoleName = g.Key,
                    TotalUsers = g.Count(),
                    ActiveUsers = g.Count(u => u.Status == UserStatus.Active),
                    InactiveUsers = g.Count(u => u.Status == UserStatus.Inactive)
                })
                .OrderByDescending(x => x.TotalUsers)
                .ToListAsync();

            return Ok(new ApiResponseDto<object>
            {
                Success = true,
                Message = "Role statistics retrieved.",
                Data = stats
            });
        }

        [HttpGet("requests/due-soon")]
        public async Task<ActionResult<ApiResponseDto<object>>> GetRequestsDueSoon()
        {
            var recentDate = DateTime.UtcNow.AddDays(-7);

            var dueSoon = await _context.ServiceRequests
                .Include(r => r.Requester)
                .Include(r => r.Department)
                .Where(r => r.CreatedAt >= recentDate)
                .Select(r => new
                {
                    r.RequestId,
                    r.RequestNumber,
                    r.Title,
                    Department = r.Department != null ? r.Department.DepartmentName : "Unknown",
                    Requestor = r.Requester != null ? r.Requester.FullName : "Unknown",
                    r.CreatedAt
                })
                .OrderByDescending(r => r.CreatedAt)
                .ToListAsync();

            return Ok(new ApiResponseDto<object>
            {
                Success = true,
                Message = "Service requests raised in last 7 days retrieved.",
                Data = dueSoon
            });
        }

        [HttpGet("departments/request-summary")]
        public async Task<ActionResult<ApiResponseDto<object>>> GetDepartmentRequestSummary()
        {
            var summary = await _context.ServiceRequests
                .Include(r => r.Department)
                .Include(r => r.Status)
                .GroupBy(r => r.Department != null ? r.Department.DepartmentName : "Unassigned")
                .Select(g => new
                {
                    Department = g.Key,
                    TotalRequests = g.Count(),
                    CompletedRequests = g.Count(x => x.Status != null && (x.Status.StatusName == "Resolved" || x.Status.StatusName == "Closed")),
                    PendingRequests = g.Count(x => x.Status != null && (x.Status.StatusName == "Open" || x.Status.StatusName == "In Progress" || x.Status.StatusName == "Pending Approval")),
                    ResolutionRatePercentage = Math.Round(g.Count() > 0 ? (g.Count(x => x.Status != null && (x.Status.StatusName == "Resolved" || x.Status.StatusName == "Closed")) / (double)g.Count()) * 100 : 0, 2)
                })
                .ToListAsync();

            return Ok(new ApiResponseDto<object>
            {
                Success = true,
                Message = "Department request summary statistics retrieved.",
                Data = summary
            });
        }

        [HttpGet("service-types/performance")]
        public async Task<ActionResult<ApiResponseDto<object>>> GetServiceTypePerformance()
        {
            var result = await _context.ServiceRequests
                .Include(r => r.ServiceType)
                .Include(r => r.Status)
                .GroupBy(r => r.ServiceType != null ? r.ServiceType.ServiceTypeName : "General")
                .Select(g => new
                {
                    ServiceType = g.Key,
                    TotalRequests = g.Count(),
                    CompletedRequests = g.Count(x => x.Status != null && (x.Status.StatusName == "Resolved" || x.Status.StatusName == "Closed")),
                    PendingRequests = g.Count(x => x.Status != null && (x.Status.StatusName == "Open" || x.Status.StatusName == "In Progress")),
                    ResolutionRatePercentage = Math.Round(g.Count() > 0 ? (g.Count(x => x.Status != null && (x.Status.StatusName == "Resolved" || x.Status.StatusName == "Closed")) / (double)g.Count()) * 100 : 0, 2)
                })
                .ToListAsync();

            return Ok(new ApiResponseDto<object>
            {
                Success = true,
                Message = "Service-type wise request performance statistics retrieved.",
                Data = result
            });
        }

        [HttpGet("departments/top-performing")]
        public async Task<ActionResult<ApiResponseDto<object>>> GetTopPerformingDepartments()
        {
            var topDepartments = await _context.ServiceRequests
                .Include(r => r.Department)
                .Include(r => r.Status)
                .GroupBy(r => r.Department != null ? r.Department.DepartmentName : "Unassigned")
                .Select(g => new
                {
                    Department = g.Key,
                    TotalRequests = g.Count(),
                    ResolutionRatePercentage = Math.Round(g.Count() > 0 ? (g.Count(x => x.Status != null && (x.Status.StatusName == "Resolved" || x.Status.StatusName == "Closed")) / (double)g.Count()) * 100 : 0, 2)
                })
                .OrderByDescending(x => x.ResolutionRatePercentage)
                .Take(10)
                .ToListAsync();

            return Ok(new ApiResponseDto<object>
            {
                Success = true,
                Message = "Top performing departments based on resolution rate retrieved.",
                Data = topDepartments
            });
        }

        [HttpGet("hods/department-stats")]
        public async Task<ActionResult<ApiResponseDto<object>>> GetHodDepartmentStats()
        {
            var hodStats = await _context.DepartmentPersonnel
                .Include(dp => dp.User)
                .Include(dp => dp.Department)
                .Where(dp => dp.IsHOD)
                .Select(dp => new
                {
                    HODName = dp.User != null ? dp.User.FullName : "Unknown",
                    DepartmentName = dp.Department != null ? dp.Department.DepartmentName : "Unknown",
                    TotalDepartmentRequests = _context.ServiceRequests.Count(r => r.DepartmentId == dp.DepartmentId),
                    PendingApprovals = _context.Approvals.Count(a => a.ServiceRequest != null && a.ServiceRequest.DepartmentId == dp.DepartmentId && a.Status == ApprovalStatus.Pending),
                    TotalPersonnel = _context.DepartmentPersonnel.Count(p => p.DepartmentId == dp.DepartmentId)
                })
                .ToListAsync();

            return Ok(new ApiResponseDto<object>
            {
                Success = true,
                Message = "HOD department workload statistics retrieved.",
                Data = hodStats
            });
        }

        [HttpGet("requestors/completion-stats")]
        public async Task<ActionResult<ApiResponseDto<object>>> GetRequestorCompletionStats()
        {
            var stats = await _context.ServiceRequests
                .Include(r => r.Requester)
                .Include(r => r.Status)
                .GroupBy(r => r.Requester != null ? r.Requester.FullName : "Unknown")
                .Select(g => new
                {
                    Requestor = g.Key,
                    TotalRequests = g.Count(),
                    CompletedRequests = g.Count(x => x.Status != null && (x.Status.StatusName == "Resolved" || x.Status.StatusName == "Closed")),
                    PendingRequests = g.Count(x => x.Status != null && (x.Status.StatusName == "Open" || x.Status.StatusName == "In Progress" || x.Status.StatusName == "Pending Approval"))
                })
                .ToListAsync();

            return Ok(new ApiResponseDto<object>
            {
                Success = true,
                Message = "Requestor ticket completion statistics retrieved.",
                Data = stats
            });
        }

        [HttpGet("requests/overdue-unresolved")]
        public async Task<ActionResult<ApiResponseDto<object>>> GetOverdueUnresolvedRequests()
        {
            var cutoffDate = DateTime.UtcNow.AddDays(-3);

            var overdue = await _context.ServiceRequests
                .Include(r => r.Requester)
                .Include(r => r.Department)
                .Include(r => r.Status)
                .Where(r => r.CreatedAt < cutoffDate && r.Status != null && r.Status.StatusName != "Resolved" && r.Status.StatusName != "Closed")
                .Select(r => new
                {
                    r.RequestNumber,
                    r.Title,
                    Requestor = r.Requester != null ? r.Requester.FullName : "Unknown",
                    Department = r.Department != null ? r.Department.DepartmentName : "Unknown",
                    Status = r.Status != null ? r.Status.StatusName : "Unknown",
                    r.CreatedAt
                })
                .ToListAsync();

            return Ok(new ApiResponseDto<object>
            {
                Success = true,
                Message = "Overdue unresolved service requests retrieved.",
                Data = overdue
            });
        }

        [HttpGet("reports/monthly-task-completion")]
        public async Task<ActionResult<ApiResponseDto<object>>> GetMonthlyTaskCompletionReport()
        {
            var monthly = await _context.ServiceRequests
                .Where(r => r.Status != null && (r.Status.StatusName == "Resolved" || r.Status.StatusName == "Closed"))
                .GroupBy(r => new
                {
                    Year = r.UpdatedAt.Year,
                    Month = r.UpdatedAt.Month
                })
                .Select(g => new
                {
                    g.Key.Year,
                    g.Key.Month,
                    CompletedRequests = g.Count()
                })
                .OrderBy(x => x.Year)
                .ThenBy(x => x.Month)
                .ToListAsync();

            return Ok(new ApiResponseDto<object>
            {
                Success = true,
                Message = "Month-wise completed request count retrieved.",
                Data = monthly
            });
        }

        [HttpGet("departments/rankings")]
        public async Task<ActionResult<ApiResponseDto<object>>> GetDepartmentRankings()
        {
            var rankedDepts = await _context.ServiceRequests
                .Include(r => r.Department)
                .Include(r => r.Status)
                .GroupBy(r => r.Department != null ? r.Department.DepartmentName : "Unassigned")
                .Select(g => new
                {
                    Department = g.Key,
                    ResolutionRatePercentage = Math.Round(g.Count() > 0 ? (g.Count(x => x.Status != null && (x.Status.StatusName == "Resolved" || x.Status.StatusName == "Closed")) / (double)g.Count()) * 100 : 0, 2)
                })
                .OrderByDescending(x => x.ResolutionRatePercentage)
                .ToListAsync();

            return Ok(new ApiResponseDto<object>
            {
                Success = true,
                Message = "Ranked departments based on resolution progress retrieved.",
                Data = rankedDepts
            });
        }

        [HttpGet("service-types/ticket-statistics")]
        public async Task<ActionResult<ApiResponseDto<object>>> GetServiceTypeTicketStatistics()
        {
            var cutoff = DateTime.UtcNow.AddDays(-3);

            var stats = await _context.ServiceRequests
                .Include(r => r.ServiceType)
                .Include(r => r.Status)
                .GroupBy(r => r.ServiceType != null ? r.ServiceType.ServiceTypeName : "General")
                .Select(g => new
                {
                    ServiceType = g.Key,
                    TotalRequests = g.Count(),
                    CompletedRequests = g.Count(x => x.Status != null && (x.Status.StatusName == "Resolved" || x.Status.StatusName == "Closed")),
                    PendingRequests = g.Count(x => x.Status != null && (x.Status.StatusName == "Open" || x.Status.StatusName == "In Progress" || x.Status.StatusName == "Pending Approval")),
                    OverdueRequests = g.Count(x => x.CreatedAt < cutoff && x.Status != null && x.Status.StatusName != "Resolved" && x.Status.StatusName != "Closed")
                })
                .ToListAsync();

            return Ok(new ApiResponseDto<object>
            {
                Success = true,
                Message = "Full ticket statistics for every service type retrieved.",
                Data = stats
            });
        }
    }
}

using QGematria;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dashboard.Pages;

public class DashboardModel : PageModel
{
    private readonly ILogger<DashboardModel> _logger;
    public Dictionary<string, List<double>> WordCoordinates { get; private set; }

    public DashboardModel(ILogger<DashboardModel> logger)
    {
        _logger = logger;
        WordCoordinates = new Dictionary<string, List<double>>();
    }

    public void OnGet()
    {
        // Enhance
        WordCoordinates = StatisticalAnalysis.AssignWordCoordinates("../QGematria/Quran/GematricalQuran.txt");
    }
}

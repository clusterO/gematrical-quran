using QGematria;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dashboard.Pages;

public class AnalyticsModel : PageModel
{
    private readonly ILogger<AnalyticsModel> _logger;
    public Dictionary<string, int> FrequencyMap { get; private set; }

    public AnalyticsModel(ILogger<AnalyticsModel> logger)
    {
        _logger = logger;
        FrequencyMap = new Dictionary<string, int>();
    }

    public void OnGet()
    {
        // Enhance
        FrequencyMap = StatisticalAnalysis.AnalyzeFrequency("../QGematria/Quran/GematricalQuran.txt");
    }
}

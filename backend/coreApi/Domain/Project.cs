namespace CoreApi.Domain;

public class Project
{
    public int Id { get; set; }
    public string ProjectName { get; set; }  = string.Empty;
    public string ProjectText { get; set; }  = string.Empty;
    public string ProjectImage { get; set; }  = string.Empty;
    public string ProjectAltText { get; set; }  = string.Empty;
    public string ProjectCategory { get; set; }  = string.Empty;
    public string GitHubUrl { get; set; } = string.Empty;
    public DateTime Date { get; set; }

}

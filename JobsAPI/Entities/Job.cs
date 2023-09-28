namespace JobsAPI.Entities;

public class Job
{
    public Job()
    {
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public int Id { get;  set; }
    public string Title { get;  set; }
    public string Description { get;  set; }
    public string Company { get;  set; }
    public string Location { get;  set; }
    public decimal Salary { get;  set; }
    public DateTime CreatedAt { get;  set; }
    public DateTime UpdatedAt { get;  set; }

    public void Update(string title, string description, string company, string location, decimal salary)
    {
        Title = title;
        Description = description;
        Company = company;
        Location = location;
        Salary = salary;

        UpdatedAt = DateTime.Now;
    }
}
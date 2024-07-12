namespace School.Infrastructure;

public class DatabaseOption {
    public const string SectionName = "Database";
    public DbConfigOption Postgres { get; set; } = new();
}

public class DbConfigOption {
    public string ConnectionString { get; set; } = string.Empty;
}

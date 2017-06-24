using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Authentication.Database
{
  public static class EntityFrameworkExtensions
  {
    public static IConfigurationBuilder AddEntityFrameworkConfig(this IConfigurationBuilder configurationBuilder, Action<DbContextOptionsBuilder> optionsBuilder)
    {
      return configurationBuilder.Add(new EntityFrameworkConfigurationSource(optionsBuilder));
    }
  }


  public class DatabaseConfigurationProvider : ConfigurationProvider
  {
    private readonly Action<DbContextOptionsBuilder> options;

    public DatabaseConfigurationProvider(Action<DbContextOptionsBuilder> options)
    {
      this.options = options;
    }

    public override void Load()
    {
     // var builder = new DbContextOptionsBuilder<DatabaseContext>();
     // options(builder);
     // using (var context = new DatabaseContext(builder.Options))
     // {
     //
     // }
    }
  }

  public class EntityFrameworkConfigurationSource : IConfigurationSource
  {
    private readonly Action<DbContextOptionsBuilder> options;

    public EntityFrameworkConfigurationSource(Action<DbContextOptionsBuilder> options)
    {
      this.options = options;
    }

    public IConfigurationProvider Build(IConfigurationBuilder builder)
    {
      return new DatabaseConfigurationProvider(options);
    }
  }
}

using System.Threading.Tasks;
using Cake.Core;
using Cake.Core.Diagnostics;
using Cake.Frosting;
using Cake.Common.IO;
using Cake.Common.IO.Paths;
using Cake.Common.Tools.DotNet;

public static class Build
{
    public static int Main(string[] args)
    {
        return new CakeHost()
            .UseContext<BuildContext>()
            .Run(args);
    }
}

public class BuildContext : FrostingContext
{
    public ConvertableDirectoryPath SolutionFolder { get; set; }
    public ConvertableDirectoryPath AppSourceFolder { get; set; }
    public ConvertableDirectoryPath ApplicationFolder { get; set; }
    public bool Delay { get; set; }

    public BuildContext(ICakeContext context) : base(context)
    {
        SolutionFolder = context.Directory("./");
        AppSourceFolder = context.Directory("source");
        ApplicationFolder = AppSourceFolder + context.Directory("App");
        //FrontentFolder = SolutionFolder + context.Directory("View");
    }
}

[TaskName("Clean")]
public sealed class CleanTask : FrostingTask<BuildContext>
{
    public override void Run(BuildContext context)
    {
        if (context.DirectoryExists("./App/bin/"))
        {
            context.CleanDirectory("./App/bin/");
        }
        if (context.DirectoryExists("./App/obj/"))
        {
            context.CleanDirectory("./App/obj/");
        }
        if (context.DirectoryExists("./publish/"))
        {
            context.CleanDirectory("./publish/");
        }
    }
}

[TaskName("Build")]
[IsDependentOn(typeof(CleanTask))]
public sealed class BuildTask : AsyncFrostingTask<BuildContext>
{
    public override Task RunAsync(BuildContext context)
    {
        context.DotNetBuild(context.SolutionFolder);
        return Task.FromResult(true);
    }
}

[TaskName("Default")]
[IsDependentOn(typeof(BuildTask))]
public class DefaultTask : FrostingTask
{

}
#addin "Cake.FileHelpers&version=3.2.1"
#addin "Cake.Xamarin&version=3.0.2"
#addin "Cake.Fastlane&version=0.7.1"


///////////////////////////////////////////////////////////////////////////////
// ARGUMENTS
///////////////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Debug");


var solutionFile = File("HTB4.sln");
var sharedProject = File("./CalculationLogic/CalculationLogic.fsproj");
var sharedBin = File("../CalculationLogic/bin");

var androidProject = File("./HTB4.Android/HTB4.Android.csproj");
var androidBin = Directory("../HTB4.Android/bin") + Directory(configuration);

var iOSProject = File("./HTB4.iOS/HTB4.iOS.csproj");
var iOSBin = Directory("../HTB4.iOS/bin/iPhone") + Directory(configuration);

var testProject = File("./CalculationLogicTests/CalculationLogicTests.fsproj");

///////////////////////////////////////////////////////////////////////////////
// SETUP / TEARDOWN
///////////////////////////////////////////////////////////////////////////////
Setup(ctx =>
{
   // Executed BEFORE the first task.
   Information("Running tasks...");
});

Teardown(ctx =>
{
   // Executed AFTER the last task.
   Information("Finished running tasks.");
});

///////////////////////////////////////////////////////////////////////////////
// PREPARATION
///////////////////////////////////////////////////////////////////////////////

Task("Clean")
    .Does(() =>
{
    CleanDirectory(androidBin);
    CleanDirectory(iOSBin);
});

Task("Restore-NuGet")
    .IsDependentOn("Clean")
    .Does(() =>
{
    NuGetRestore(solutionFile);
});

///////////////////////////////////////////////////////////////////////////////
// Shared
///////////////////////////////////////////////////////////////////////////////

Task("Build-Shared")
    .IsDependentOn("Restore-NuGet")
    .Does(() =>
{
 	MSBuild(sharedProject, settings =>
        settings.SetConfiguration(configuration));
});

///////////////////////////////////////////////////////////////////////////////
// ANDROID
///////////////////////////////////////////////////////////////////////////////

Task("Build-Android")
    .IsDependentOn("Restore-NuGet")
    .Does(() =>
{
 	MSBuild(androidProject, settings =>
        settings.SetConfiguration(configuration));
            
});

Task("Submit-Android")
    .IsDependentOn("Build-Android")
    .Does(()=>{
        Fastlane.Supply(config =>
        {
            config.ApkFilePath = "./artifacts/android/cake.fastlane.apk";
            config.SkipUploadMetadata = true;
            config.SkipUploadImages = true;
            config.SkipUploadScreenShots = true;
        });
    });

///////////////////////////////////////////////////////////////////////////////
// IOS
///////////////////////////////////////////////////////////////////////////////

Task("Build-iOS")
    .WithCriteria(IsRunningOnUnix())
    .IsDependentOn("Build-Android")
    .Does(() =>
{
    MSBuild (iOSProject, settings => 
	    settings.SetConfiguration(configuration)
    		.WithProperty("Platform", "iPhone")
    		.WithProperty("OutputPath", $"bin/iPhone/{configuration}/"));
});

///////////////////////////////////////////////////////////////////////////////
// Test
///////////////////////////////////////////////////////////////////////////////

Task("test")
  .IsDependentOn("Build-Shared")
  .Does(() => 
  {
    DotNetCoreTest(testProject);
  });

///////////////////////////////////////////////////////////////////////////////
// Build
///////////////////////////////////////////////////////////////////////////////

Task("build")
	.IsDependentOn("Build-Android")
	.IsDependentOn("Build-iOS");


Task("build-sln")
	.Does(() =>
{ 
    try{
        MSBuild(solutionFile, GetMSBuildSettings().WithRestore());
    }
    catch(Exception)
    {
        if(IsRunningOnWindows())
            throw;
    }
});

///////////////////////////////////////////////////////////////////////////////
// Default
///////////////////////////////////////////////////////////////////////////////

Task("Default")
    .IsDependentOn("build")
  .Does(() =>
{
  Information("Running Default task");
});

RunTarget(target);


MSBuildSettings GetMSBuildSettings()
{
    return new MSBuildSettings {
        PlatformTarget = PlatformTarget.MSIL,
        MSBuildPlatform = Cake.Common.Tools.MSBuild.MSBuildPlatform.x86,
        Configuration = configuration,
    };
}
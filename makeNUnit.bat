rem ****
rem * Command line build - For CppUTest - Run from CppUTest directory
rem * 
rem * this path works on my machine
rem ****PATH=C:\Windows\Microsoft.NET\Framework\v4.0.30319;

rem directory of executing batch file
pushd %~dp0

set nunit_console_exe=.\NUnit\bin\Debug\nunit-console.exe
if exist %nunit_console_exe% goto SKIP

C:\Windows\Microsoft.NET\Framework\v4.0.30319\msbuild /t:build /verbosity:quiet .\NUnit\nunit.sln

:SKIP
popd
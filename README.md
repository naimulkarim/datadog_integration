In modern cloud-native and microservices architectures, applications are highly distributed, making it difficult to detect failures and performance bottlenecks and monitoring and analytics tools are essential to ensure the performance and reliability of web services and applications. Among these tools, Datadog is popular choice. Its is a cloud-based monitoring and security platform that provides real-time observability for applications, infrastructure, logs, and security across distributed systems. It integrates with cloud providers, containers, databases, and third-party services, allowing teams to track performance, troubleshoot issues, and ensure system reliability.

Here’s how it can be set up:

Required Nuget Packages

Serilog.AspNetCore Serilog logging for ASP.NET Core

Serilog.Sinks.Datadog.Logs A Serilog sink that sends events and logs straight away to Datadog. By default the sink sends logs over HTTPS

Step 1 : Sign up for a Datadog account Also note the region of your Datadog site. In my case it was US5 (us5.datadoghq.com)

Step 2 : Get the API Key Get the API key from Data log portal

Step 3 : Get the Logging Endpoints Use the site selector dropdown on the right side of the page to see supported endpoints by Datadog site (https://docs.datadoghq.com/logs/log_collection/?tab=host#supported-endpoints). This is needed in configuration URL of appsettings.

Step 4: Configure Serilog and Datadog in appsettings.json In apssettings.json add the necessary configuration for Serilog and Datadog. The following set up includes specifying sinks for the console and Datadog, setting minimum log levels, defining service properties and the enrichment of logs.

Step 5: Initialize Serilog in Program.cs The following code reads the configurations from appsettings.json and adds serilog to the logging providers.

Step 6: Use Logging in Controller and Services Finally create logs by injecting the ILogger logger into the class where you want to use it. Hit your api controller.

Step 7: View logs in Datadog Go to Datadog portal and then navigate to Logs -> Explorer to view logs.

Done!

Thanks for reading !

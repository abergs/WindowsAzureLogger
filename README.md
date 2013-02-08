WindowsAzureLogger
==================

Contains a Logger that batches messages and persits them in Windows Azure Table Storage

Contains a Web MVC 4 project with a page that auto refreshes to display revent log entries.

Edit the cloud configurations to set your StorageConnectionString


Logging in Windows Azure can be done though Windows Azure Diagnostics. This solutions collects a ton of detailed data that can be hard to parse through. I recently needed a close to real-time trace of what my Roles were doing. My current project has many instances with many independent services running in parallel, resulting in a challenge when I try to trace using Windows Azure Diagnostics. Log4Net and Enterprise Library offer amazing tools to accomplish what I’m after. But they do so with so much detail and data, that we often need to resort to parsing tools and third party applications to extract meaningful information. I needed something quick, lightweight and that didn’t cost too much to operate.

At first, I was trying to follow what my instances were up to using the Windows Azure Compute Emulator. This wasn’t what I was looking for, because local environments don’t run exactly like the production or staging environments on the cloud. I spent a few minutes thinking about logging and costs related to Windows Azure Storage transactions and came up with the solution described below.


Read more at http://alexandrebrisebois.wordpress.com/2013/02/08/service-logger-for-windows-azure-roles-using-table-storage-service

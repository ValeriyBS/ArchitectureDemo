# ArchitectureDemo
This project was started with the sole purpose to learn best practices in software design.</br>
I wanted to have first hand experience of the pros and cons of using Clean Architecture with Screaming Design and CQRS pattern in ASP.net Core.</br>
It is work in progress at this stage, but I hope to find the time to finish in the near future.</br> 
The end result should be a Docker containerised web application with automatic deployment from Visual Studio.
I have separated the identity and application context into separate databases, so they have to be created before running the project.</br>
In order to do that you have to type in Package Management Console :</br>
update-database -context ApplicationDbContext</br>
update-database -context DatabaseContext</br>

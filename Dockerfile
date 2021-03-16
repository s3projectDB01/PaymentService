FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app 
#
# copy csproj and restore as distinct layers
COPY *.sln .
COPY MenuApp.PaymentService/*.csproj ./MenuApp.PaymentService/
COPY MenuApp.PaymentService.EntityFramework/*.csproj ./MenuApp.PaymentService.EntityFramework/
COPY MenuApp.PaymentService.Logic/*.csproj ./MenuApp.PaymentService.Logic/
#
RUN dotnet restore 
#
# copy everything else and build app
COPY MenuApp.PaymentService/. ./MenuApp.PaymentService/
COPY MenuApp.PaymentService.EntityFramework/. ./MenuApp.PaymentService.EntityFramework/
COPY MenuApp.PaymentService.Logic/. ./MenuApp.PaymentService.Logic/
#
WORKDIR /app/MenuApp.PaymentService
RUN dotnet publish -c Release -o out 
#
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime
WORKDIR /app 
#
COPY --from=build /app/MenuApp.PaymentService/out ./

EXPOSE 80
ENTRYPOINT ["dotnet", "MenuApp.PaymentService.dll"]
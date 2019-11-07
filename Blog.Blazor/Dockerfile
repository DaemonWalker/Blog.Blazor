#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Blog.Blazor/Blog.Blazor.csproj", "Blog.Blazor/"]
COPY ["MyBlog.Data/Blog.Data.csproj", "MyBlog.Data/"]
COPY ["Blog.Shared/Blog.Shared.csproj", "Blog.Shared/"]
COPY ["MyBlog.Model/Blog.Model.csproj", "MyBlog.Model/"]
RUN dotnet restore "Blog.Blazor/Blog.Blazor.csproj"
COPY . .
WORKDIR "/src/Blog.Blazor"
RUN dotnet build "Blog.Blazor.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Blog.Blazor.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Blog.Blazor.exe"]
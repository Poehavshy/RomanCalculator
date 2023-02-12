FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["RomanExpression.Application/RomanExpression.Application.csproj", "RomanExpression.Application/"]
COPY ["RomanExpression.Calculator/RomanExpression.Calculator.csproj", "RomanExpression.Calculator/"]
COPY ["RomanExpression.Translator/RomanExpression.Translator.csproj", "RomanExpression.Translator/"]
RUN dotnet restore "RomanExpression.Application/RomanExpression.Application.csproj"
COPY . .
WORKDIR "/src/RomanExpression.Application"
RUN dotnet build "RomanExpression.Application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RomanExpression.Application.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RomanExpression.Application.dll"]

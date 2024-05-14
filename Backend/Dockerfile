FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app

COPY *.csproj ./

RUN dotnet restore

COPY . ./
COPY ./Infrastructure/Repositories/Api/template.docx ./
COPY ./Infrastructure/Repositories/Api/times.ttf ./

RUN dotnet build -c Release -o out


FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

WORKDIR ./
COPY --from=build /app/times.ttf ./usr/share/fonts/times.ttf

WORKDIR /app
COPY --from=build /app/template.docx ./
COPY --from=build /app/out ./
ENTRYPOINT ["dotnet", "Backend.dll"]
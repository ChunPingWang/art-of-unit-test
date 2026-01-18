# Art of Unit Testing - .NET 8 版本

本專案是《The Art of Unit Testing, 2nd Edition》範例程式碼的 .NET 8 現代化版本。

## 系統需求

- .NET 8.0 SDK
- Visual Studio 2022 / VS Code / Rider
- Windows / macOS / Linux

## 快速開始

```bash
# 還原套件
dotnet restore

# 建置專案
dotnet build

# 執行測試
dotnet test

# 產生程式碼覆蓋率報告
dotnet test --collect:"XPlat Code Coverage"
```

## 專案列表

| 專案 | 類型 | 說明 |
|------|------|------|
| Chapter1 | 類別庫 | 第一章：SimpleParser 基礎範例 |
| Chapter1.ConsoleApp | 主控台 | 執行第一章測試 |
| LogAn | 類別庫 | LogAnalyzer 核心類別 |
| LogAn.UnitTests | 測試 | LogAnalyzer 單元測試 |
| Chapter5.LogAn | 類別庫 | 第五章：依賴注入範例 |
| NSubExamples | 測試 | NSubstitute 隔離框架範例 |
| Examples | 類別庫 | 其他範例程式 |
| Examples.Tests | 測試 | 其他範例測試 |
| AppendixB.IntegrationTests | 測試 | 整合測試範例 |

## 使用的套件

- NUnit 4.2.2
- NUnit3TestAdapter 4.6.0
- Microsoft.NET.Test.Sdk 17.11.1
- NSubstitute 5.1.0
- Moq 4.20.72
- coverlet.collector 6.0.2

## .NET 8 現代化特性

本版本使用了 .NET 8 / C# 12 的現代語法特性：

### 檔案範圍命名空間

```csharp
// 舊語法
namespace LogAn
{
    public class LogAnalyzer { }
}

// 新語法（本專案使用）
namespace LogAn;

public class LogAnalyzer { }
```

### 目標類型 new

```csharp
// 舊語法
LogAnalyzer analyzer = new LogAnalyzer();

// 新語法
LogAnalyzer analyzer = new();
```

### 表達式主體成員

```csharp
// 舊語法
public int Sum()
{
    return _sum;
}

// 新語法
public int Sum() => _sum;
```

### Nullable 參考類型

```csharp
// 啟用 nullable
#nullable enable

public string? Name { get; set; }
```

### 全域 using

每個專案的 `ImplicitUsings` 設定為 `enable`，自動引入常用命名空間。

## 跨平台支援

.NET 8 版本可在以下平台執行：

- Windows x64/x86/ARM64
- macOS x64/ARM64 (Apple Silicon)
- Linux x64/ARM64

## 程式碼覆蓋率

使用 coverlet 產生覆蓋率報告：

```bash
dotnet test --collect:"XPlat Code Coverage" --results-directory ./coverage

# 安裝 ReportGenerator 工具
dotnet tool install -g dotnet-reportgenerator-globaltool

# 產生 HTML 報告
reportgenerator -reports:./coverage/**/coverage.cobertura.xml -targetdir:./coverage/report -reporttypes:Html
```

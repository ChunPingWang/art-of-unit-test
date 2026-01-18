# Art of Unit Testing - .NET Framework 4.8 版本

本專案是《The Art of Unit Testing, 2nd Edition》範例程式碼的 .NET Framework 4.8 現代化版本。

## 系統需求

- Visual Studio 2019/2022
- .NET Framework 4.8 SDK
- Windows 作業系統

## 快速開始

```bash
# 還原套件
dotnet restore

# 建置專案
dotnet build

# 執行測試
dotnet test
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

## 與 .NET Core 版本的差異

- 使用 `net48` 目標框架
- 語法保持傳統 C# 風格
- 使用 `System.Data.SqlClient` 而非 `Microsoft.Data.SqlClient`

一个基于WPF的常用工具，记录一下，把工作中能够提供便利的都加上去# Tools Solution

## 项目概述

`Tools` 是一个多项目解决方案，旨在提供一系列工具和功能模块。该解决方案使用 C# 编写，并基于 .NET 平台开发。当前解决方案包含以下三个主要项目：

- **Tools**: 主要的工具应用程序。
- **UseMvvm**: 使用 MVVM 模式实现的项目。
- **Shared**: 共享库，提供跨项目使用的公共类和方法。

## 项目结构

### Tools (Tools.csproj)

- **描述**: 主要的工具应用程序，负责提供核心功能。
- **位置**: `Tools/Tools.csproj`

### UseMvvm (UseMvvm.csproj)

- **描述**: 使用 MVVM 模式实现的项目，通常用于 WPF 应用程序。
- **位置**: `UseMvvm/UseMvvm.csproj`

### Shared (Shared.csproj)

- **描述**: 共享库，包含可在多个项目中复用的代码。
- **位置**: `Shared/Shared.csproj`

## 构建和运行

### 编译

- Visual Studio 2022 或更高版本
- .net framework 4.8

### 构建步骤

1. 打开 `Tools.sln` 文件。
2. 在 Visual Studio 中选择构建菜单下的“生成解决方案”选项。
3. 构建完成后，可以在输出目录找到生成的可执行文件和依赖项。

### 运行应用程序

- 打开生成的可执行文件（通常位于 `bin/Debug` 或 `bin/Release` 目录下）。
- 根据具体项目的需求启动相应的应用程序。

## 项目配置

### 配置平台

解决方案配置为支持以下平台：

- Debug|Any CPU
- Release|Any CPU

### 配置属性

- `HideSolutionNode = FALSE`: 解决方案节点在解决方案资源管理器中可见。
- `SolutionGuid`: 解决方案的唯一标识符。

## 贡献指南

欢迎贡献者参与本项目的开发和改进。请遵循以下步骤进行贡献：

1. Fork 本仓库。
2. 创建新分支 (`git checkout -b feature-branch`)。
3. 提交更改 (`git commit -am 'Add some feature'`)。
4. 推送到分支 (`git push origin feature-branch`)。
5. 提交拉取请求。

## 许可证

本项目采用 MIT 许可证，详情请参阅 [LICENSE](LICENSE) 文件。


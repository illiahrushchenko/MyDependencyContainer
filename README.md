# MyDependencyContainer

Welcome to the Custom IoC Container project! This project demonstrates the implementation of a simple Inversion of Control (IoC) container in C#. IoC containers are essential tools in modern software development, allowing for more flexible and decoupled code.

## Overview

This project showcases the creation of a custom IoC container, which is a fundamental component in the Dependency Injection pattern. The IoC container helps manage object creation and the resolution of dependencies within your application.

## Features

- **Dependency Registration**: Register your application's dependencies with the container.

- **Dependency Resolution**: Resolve dependencies automatically when needed.

- **Singleton and Transient Lifetime**: Support for both singleton and transient object lifetimes.

- **Constructor Injection**: Automatically inject dependencies into constructors.

## Getting Started

To get started with this custom IoC container, follow these steps:

1. Clone the repository:

   ```bash
   git clone git@github.com:illiahrushchenko/MyDependencyContainer.git
   cd MyDependecyContainer
   ```
2. Explore the code in the MyDependecyContainer folder to understand how the IoC container is implemented.
3. Check the ContainerDemo folder for an example of how to use the custom IoC container in a simple application.

## Usage

1. Register Dependencies:
Register your dependencies in the IoC container. For example:
```cs
var ioc = new MyIoc();
ioc.Register<MyService>();
ioc.RegisterSingleton<MySingletonService>();
```
2. Resolve Dependencies:
Resolve your dependencies from the container. For example:
```cs
var service = ioc.Resolve<MyService>();
```
3. Constructor Injection:
The container will automatically inject dependencies into constructors when resolving objects.
```cs
public class MyService
{
    private readonly MySingletonService _mySingletonService;

    public MyService(MySingletonService mySingletonService)
    {
        _mySingletonService = mySingletonService;
    }

    // ...
}
```
## License
This project is licensed with the [MIT license](https://github.com/illiahrushchenko/MyDependencyContainer/blob/master/LICENSE).

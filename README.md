# NServiceBus.CustomChecks.Http

[![Build status](https://img.shields.io/appveyor/build/TraGicCode/NServiceBus-CustomChecks-Http/master)](https://ci.appveyor.com/project/TraGicCode/NServiceBus-CustomChecks-Http)
[![Nuget](https://img.shields.io/nuget/v/NServiceBus.CustomChecks.Http)](https://www.nuget.org/packages/NServiceBus.CustomChecks.Http)
[![Nuget downloads](https://img.shields.io/nuget/dt/NServiceBus.CustomChecks.Http)](https://www.nuget.org/packages/NServiceBus.CustomChecks.Http)
[![License](https://img.shields.io/github/license/TraGicCode/NServiceBus.CustomChecks.Http.svg)](https://github.com/TraGicCode/NServiceBus.CustomChecks.Http/blob/master/LICENSE)

#### Table of Contents

1. [Description](#description)
1. [How to use it](#how-to-use-it)
1. [How it works](#how-it-works)
1. [Development - Guide for contributing](#contributing)

## Description

A Reusable NServiceBus CustomCheck to check the availability and connectivity of Http Endpoints.

## How to use it

In order to begin using this custom check simply create a child class for each instance you would like to perform a healthcheck on.

```c#
namespace Ordering.Endpoint.CustomChecks
{
    public class GitHubHttpApiCustomCheck : HttpCustomCheck
    {
        private static TimeSpan repeat = TimeSpan.FromSeconds(5);
        private static string httpUrl = "https://api.github.com";
        
        public GitHubHttpApiCustomCheck(): base(url: httpUrl, id: $"Monitor {httpUrl}", "Third Party Dependency", repeat)
        {

        }
    }
}
```

## Contributing

1. Fork it ( <https://github.com/tragiccode/NServiceBus.CustomChecks.Http/fork> )
1. Create your feature branch (`git checkout -b my-new-feature`)
1. Commit your changes (`git commit -am 'Add some feature'`)
1. Push to the branch (`git push origin my-new-feature`)
1. Create a new Pull Request
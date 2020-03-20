# SharpML

[![Build Status](https://travis-ci.org/joemccann/dillinger.svg?branch=master)](https://travis-ci.org/joemccann/dillinger)

SharpML is a proof of concept file share data mining tool using Machine Learning in Python and C#.

The tool is discussed in more detail on our blog here, but is summarised below also:

SharpML is C# and Python based tool that performs a number of operations with a view to mining file shares, querying Active Directory for users, dropping an ML model and associated rules, perfoming Active Directory authentication checks, with a view to automating the process of hunting for passwords in file shares by feeding the mined data into the ML model.

The ML model is written in Python, and has been developed using a custom algorithm to identify likelyhoods of passwords. The model has been compiled with PyInstaller and sits as resource file in the C# wrapper, which interops between itself, the data and the model. The program logic can be seen below:

![Program_logic](img/sharpml_logic.png)

Currently it allows for a single file share to be assessed.

You will need to have read access to the file share you are targeting, after which the tool will perform its activities mostly autonomously.

There a compiled release in the release section, and it is to be noted that this tool is currently a PoC and subject to numerous improvements.

## Usage:

```
> SharpML.exe

```

## Authors

Marco Valentini

Tom Kallo

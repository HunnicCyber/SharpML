# Fene

[![Build Status](https://travis-ci.org/joemccann/dillinger.svg?branch=master)](https://travis-ci.org/joemccann/dillinger)

SharpML is a proof of concept Active Directory data mining tool using Machine Learning in Python and C#.

The tool is discussed in more detail on our blog here: but is summarised below also:

[![GUI VIEW](/img/github.png)

## usage:

```
> SharpML.exe

SharpML: This tool will mine Active Directory, taking all text based files, line by line and copy them to the workstation. It will then create a list of AD users and write these to the workstation also. It will then drop the Machine Learning algorithm to the temp folder, and feed in the raw data and evaluate for password likelyhood where line exist with a username. If the check parameter is passed, these founds user/password combinations will be validated against a domain controller

Usage:

Standard Run:   SharpML.exe

Check Run:    SharpML.exe check
```

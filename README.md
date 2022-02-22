# Overview

This package allows you to create immutable collections that are compared by value instead of by reference. This can be particularly useful when you want to use record types in C#, especially since often records contain properties that are lists. By default, all collections compare by reference, which makes the auto-generated equality checks for record types far less useful. When using any of the value immutable collection types, this problem no longer occurs.

[![.NET](https://github.com/charliebillen/ShuntingYardApi/actions/workflows/ci.yml/badge.svg)](https://github.com/charliebillen/ShuntingYardApi/actions/workflows/ci.yml)

# Shunting Yard API

An ASP.net 6 API that accepts a calculation as a string and uses an implementation of the [Shunting Yard (Wikipedia)](https://en.wikipedia.org/wiki/Shunting_yard_algorithm) algorithm to calculate and return the solution.

## Example
```
GET /solutions/(1+2.5)*(3+4) => 24.5
```

## What's implemented?
- Multiplication, division, addition, subtraction
- Brackets and nested brackets
- Decimal operands

## What's not implemented?
- Negative operands
- Calculation validation
- Error handling

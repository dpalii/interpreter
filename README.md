# Interpreter

In this example, we have implemented a simple interpreter pattern to evaluate arithmetic expressions. We have two types of expressions: NumberExpression for terminal expressions (constants) and AddExpression and SubtractExpression for non-terminal expressions (addition and subtraction). The Context class holds variables and their corresponding expressions.

The client code sets up the expressions and the context, creates the expression tree, and interprets it by calling the Interpret method on the root expression. The result is then displayed on the console.

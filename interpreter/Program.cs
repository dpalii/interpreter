using System;
using System.Collections.Generic;

// Abstract expression interface
public interface IExpression
{
    int Interpret();
}

// Terminal expression implementation
public class NumberExpression : IExpression
{
    private int number;

    public NumberExpression(int number)
    {
        this.number = number;
    }

    public int Interpret()
    {
        return number;
    }
}

// Non-terminal expression implementation
public class AddExpression : IExpression
{
    private IExpression leftExpression;
    private IExpression rightExpression;

    public AddExpression(IExpression leftExpression, IExpression rightExpression)
    {
        this.leftExpression = leftExpression;
        this.rightExpression = rightExpression;
    }

    public int Interpret()
    {
        return leftExpression.Interpret() + rightExpression.Interpret();
    }
}

// Non-terminal expression implementation
public class SubtractExpression : IExpression
{
    private IExpression leftExpression;
    private IExpression rightExpression;

    public SubtractExpression(IExpression leftExpression, IExpression rightExpression)
    {
        this.leftExpression = leftExpression;
        this.rightExpression = rightExpression;
    }

    public int Interpret()
    {
        return leftExpression.Interpret() - rightExpression.Interpret();
    }
}

// Context class
public class Context
{
    private Dictionary<char, IExpression> variables;

    public Context()
    {
        variables = new Dictionary<char, IExpression>();
    }

    public void SetVariable(char variableName, IExpression expression)
    {
        variables[variableName] = expression;
    }

    public IExpression GetVariable(char variableName)
    {
        if (variables.ContainsKey(variableName))
        {
            return variables[variableName];
        }
        throw new Exception($"Variable '{variableName}' not found");
    }
}

// Client code
public class Program
{
    static void Main()
    {
        // Create expressions
        IExpression fiveExpression = new NumberExpression(5);
        IExpression tenExpression = new NumberExpression(10);
        IExpression xExpression = new NumberExpression(3);
        IExpression yExpression = new NumberExpression(2);

        // Create the context and set variables
        Context context = new Context();
        context.SetVariable('x', xExpression);
        context.SetVariable('y', yExpression);

        // Create the expression tree: 5 + 10 - x + y
        IExpression expression = new SubtractExpression(
            new AddExpression(fiveExpression, tenExpression),
            new AddExpression(context.GetVariable('x'), context.GetVariable('y'))
        );

        // Interpret the expression
        int result = expression.Interpret();
        Console.WriteLine($"Result: {result}"); // Output: Result: 20

        Console.ReadLine();
    }
}

﻿using System;
using System.Linq.Expressions;

namespace ExpressionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Manually build the expression tree for the lambda expression num => num < 5
            /*ParameterExpression numParam = Expression.Parameter(typeof(int), "num");
            ConstantExpression five = Expression.Constant(5, typeof(int));
            BinaryExpression numLessThanFive = Expression.LessThan(numParam, five);
            Expression<Func<int, bool>> lambda1 = Expression.Lambda<Func<int, bool>>(numLessThanFive, new ParameterExpression[] { numParam });
            Console.WriteLine(lambda1);*/
            #endregion

            #region MyRegion
            ParameterExpression value = Expression.Parameter(typeof(int), "value");
            ParameterExpression result = Expression.Parameter(typeof(int), "result");

            // Creating a label to jump to from a loop.  
            LabelTarget label = Expression.Label(typeof(int));

            // Creating a method body.  
            BlockExpression block = Expression.Block(
                    // Adding a local variable.  
                    new[] { result },
                    // Assigning a constant to a local variable: result = 1  
                    Expression.Assign(result, Expression.Constant(1)),
                    // Adding a loop.  
                    Expression.Loop(
                        // Adding a conditional block into the loop.  
                        Expression.IfThenElse(
                            // Condition: value > 1  
                            Expression.GreaterThan(value, Expression.Constant(1)),
                            // If true: result *= value --  
                            Expression.MultiplyAssign(result,Expression.PostDecrementAssign(value)),
                            // If false, exit the loop and go to the label.  
                            Expression.Break(label, result)
                        ),
                    // Label to jump to.  
                    label
                )
            );

            Console.WriteLine(Expression.Lambda<Func<int, int>>(block, value));
            // Compile and execute an expression tree.  
            int factorial = Expression.Lambda<Func<int, int>>(block, value).Compile()(5);
            Console.WriteLine(factorial);
            // Prints 120.
            #endregion

            Console.ReadKey();
        }
    }
}

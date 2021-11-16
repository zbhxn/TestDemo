using System.Linq.Expressions;

LabelTarget labelBreak = Expression.Label();
ParameterExpression loopIndex = Expression.Parameter(typeof(int), "index");

BlockExpression block = Expression.Block(
    new[] { loopIndex },
    // 初始化loopIndex = 1
    Expression.Assign(loopIndex, Expression.Constant(1)),
    Expression.Loop(
        Expression.IfThenElse(
            // if的判断逻辑
            Expression.LessThanOrEqual(loopIndex, Expression.Constant(10)),
            // 判断逻辑通过的代码
            Expression.Block(
                Expression.Call(
                    null,
                    typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) })!,
                    Expression.Constant("Hello")
                ),
                Expression.PostIncrementAssign(loopIndex)
            ),
            // 判断不通过的代码
            Expression.Break(labelBreak)
        ),
        labelBreak
    )
);

// 将我们上面的代码块表达式
Expression<Action> lambdaExpression = Expression.Lambda<Action>(block);
lambdaExpression.Compile().Invoke();

/*() =>
{
    var index = 1;
    while (true)
    {
        if (index <= 10)
        {
            Console.WriteLine("Hello");
            index++;
        }
        else
        {
            break;
        }
    }
}*/
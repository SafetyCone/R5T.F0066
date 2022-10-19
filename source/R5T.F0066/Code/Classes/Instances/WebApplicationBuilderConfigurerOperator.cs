using System;


namespace R5T.F0066
{
	public class WebApplicationBuilderConfigurerOperator : IWebApplicationBuilderConfigurerOperator
	{
		#region Infrastructure

	    public static IWebApplicationBuilderConfigurerOperator Instance { get; } = new WebApplicationBuilderConfigurerOperator();

	    private WebApplicationBuilderConfigurerOperator()
	    {
        }

	    #endregion
	}
}
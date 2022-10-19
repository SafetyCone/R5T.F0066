using System;


namespace R5T.F0066
{
	public class WebApplicationConfigurerOperator : IWebApplicationConfigurerOperator
	{
		#region Infrastructure

	    public static IWebApplicationConfigurerOperator Instance { get; } = new WebApplicationConfigurerOperator();

	    private WebApplicationConfigurerOperator()
	    {
        }

	    #endregion
	}
}
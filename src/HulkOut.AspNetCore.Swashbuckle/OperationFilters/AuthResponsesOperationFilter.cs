﻿using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace HulkOut.AspNetCore.Swashbuckle.OperationFilters
{
	public class AuthResponsesOperationFilter : IOperationFilter
	{
		public void Apply(OpenApiOperation operation, OperationFilterContext context)
		{
			var authAttribute = context.MethodInfo.GetCustomAttributes(true)
														.OfType<AuthorizeAttribute>()
														.FirstOrDefault() ??
													context.MethodInfo.DeclaringType?.GetCustomAttributes(true)
														.OfType<AuthorizeAttribute>()
														.FirstOrDefault();

			if (authAttribute == null) return;

			operation.Responses.Add(((int)HttpStatusCode.Unauthorized).ToString(),
				new OpenApiResponse { Description = "Unauthorized" });
			operation.Responses.Add(((int)HttpStatusCode.Forbidden).ToString(),
				new OpenApiResponse { Description = "Forbidden" });

			operation.Responses.Extensions.Add("x-allowed-roles", new OpenApiString(authAttribute.Roles));
		}
	}
}
﻿using HulkOut.Core.Interfaces;
using HulkOut.Models.Data;
using HulkOut.Models.Enums;

namespace HulkOut.Interfaces.Auditing
{
	/// <summary>
	/// </summary>
	/// <seealso cref="HulkOut.Core.Interfaces.IBaseService{HulkOut.Models.Data.Audit}" />
	public interface IAuditSerivce : IBaseService<Audit>
	{
		/// <summary>
		///   Writes the audit.
		/// </summary>
		/// <param name="description">The description.</param>
		/// <param name="auditAction">The audit action.</param>
		void WriteAudit(string description, AuditEnums.AuditAction auditAction);

		/// <summary>
		///   Writes the audit.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="description">The description.</param>
		/// <param name="auditAction">The audit action.</param>
		/// <param name="originalObject">The original object.</param>
		/// <param name="newObject">The new object.</param>
		void WriteAudit<T>(string description, AuditEnums.AuditAction action, T originalObject, T newObject);
	}
}
﻿using AuctionSniper.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuctionSniper.Domain.Entities;

public class Position : AuditableBaseEntity
{
	public string PositionTitle { get; set; }
	public string PositionNumber { get; set; }
	public string PositionDescription { get; set; }
	public string PostionArea { get; set; }
	public string PostionType { get; set; }
	[Column(TypeName = "decimal(18,2)")]
	public decimal PositionSalary { get; set; }
}
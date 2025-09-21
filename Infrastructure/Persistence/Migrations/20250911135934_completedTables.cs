using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
	/// <inheritdoc />
	public partial class completedTables : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "AspNetRoles",
				columns: table => new
				{
					Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
					Name = table.Column<string>(type: "nvarchar(200)", maxLength: 256, nullable: false),
					NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
					ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AspNetRoles", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "AspNetUsers",
				columns: table => new
				{
					Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
					Name = table.Column<string>(type: "nvarchar(200)", nullable: false),
					IsActive = table.Column<bool>(type: "bit", nullable: false),
					UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
					Email = table.Column<string>(type: "NVARCHAR(200)", maxLength: 256, nullable: false),
					PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
					PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AspNetUsers", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Categories",
				columns: table => new
				{
					Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
					Name = table.Column<string>(type: "nvarchar(200)", nullable: false),
					Description = table.Column<string>(type: "nvarchar(MAX)", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Categories", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Customers",
				columns: table => new
				{
					Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
					Name = table.Column<string>(type: "nvarchar(200)", nullable: false),
					Email = table.Column<string>(type: "NVARCHAR(200)", nullable: false),
					Phone = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
					Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Customers", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Employee",
				columns: table => new
				{
					Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
					Name = table.Column<string>(type: "nvarchar(200)", nullable: false),
					JobTitle = table.Column<string>(type: "varchar(100)", nullable: false),
					HireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
					Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Employee", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Suppliers",
				columns: table => new
				{
					Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
					Name = table.Column<string>(type: "nvarchar(200)", nullable: false),
					Email = table.Column<string>(type: "NVARCHAR(200)", nullable: false),
					Phone = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
					Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Suppliers", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Units",
				columns: table => new
				{
					Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
					Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
					QuantityOf = table.Column<int>(type: "int", nullable: false),
					ProductUnitId = table.Column<int>(type: "int", nullable: true),
					UnitId = table.Column<string>(type: "nvarchar(450)", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Units", x => x.Id);
					table.ForeignKey(
						name: "FK_Units_Units_UnitId",
						column: x => x.UnitId,
						principalTable: "Units",
						principalColumn: "Id");
				});

			migrationBuilder.CreateTable(
				name: "Warehouses",
				columns: table => new
				{
					Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
					Name = table.Column<string>(type: "nvarchar(200)", nullable: false),
					Location = table.Column<string>(type: "NVARCHAR(300)", nullable: false),
					Description = table.Column<string>(type: "nvarchar(MAX)", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Warehouses", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "AspNetUserRoles",
				columns: table => new
				{
					UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
					RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
					UserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
					table.ForeignKey(
						name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
						column: x => x.RoleId,
						principalTable: "AspNetRoles",
						principalColumn: "Id",
						onDelete: ReferentialAction.NoAction);
					table.ForeignKey(
						name: "FK_AspNetUserRoles_AspNetUsers_UserId",
						column: x => x.UserId,
						principalTable: "AspNetUsers",
						principalColumn: "Id",
						onDelete: ReferentialAction.NoAction);
					table.ForeignKey(
						name: "FK_AspNetUserRoles_AspNetUsers_UserId1",
						column: x => x.UserId1,
						principalTable: "AspNetUsers",
						principalColumn: "Id");
				});

			migrationBuilder.CreateTable(
				name: "Notifications",
				columns: table => new
				{
					Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
					Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
					DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
					IsRead = table.Column<bool>(type: "bit", nullable: false),
					UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Notifications", x => x.Id);
					table.ForeignKey(
						name: "FK_Notifications_AspNetUsers_UserId",
						column: x => x.UserId,
						principalTable: "AspNetUsers",
						principalColumn: "Id");
				});

			migrationBuilder.CreateTable(
				name: "RefreshTokens",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Expires = table.Column<DateTime>(type: "datetime2", nullable: false),
					Created = table.Column<DateTime>(type: "datetime2", nullable: false),
					Revoked = table.Column<DateTime>(type: "datetime2", nullable: true),
					UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_RefreshTokens", x => x.Id);
					table.ForeignKey(
						name: "FK_RefreshTokens_AspNetUsers_UserId",
						column: x => x.UserId,
						principalTable: "AspNetUsers",
						principalColumn: "Id",
						onDelete: ReferentialAction.NoAction);
				});

			migrationBuilder.CreateTable(
				name: "Receipts",
				columns: table => new
				{
					Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
					Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
					Date = table.Column<DateTime>(type: "datetime2", nullable: false),
					Notes = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
					CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Receipts", x => x.Id);
					table.ForeignKey(
						name: "FK_Receipts_Customers_CustomerId",
						column: x => x.CustomerId,
						principalTable: "Customers",
						principalColumn: "Id",
						onDelete: ReferentialAction.NoAction);
				});

			migrationBuilder.CreateTable(
				name: "Payrolls",
				columns: table => new
				{
					Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
					EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
					Month = table.Column<int>(type: "int", nullable: false),
					Year = table.Column<int>(type: "int", nullable: false),
					BaseSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
					Allowances = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
					Deductions = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
					Overtime = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Payrolls", x => x.Id);
					table.ForeignKey(
						name: "FK_Payrolls_Employee_EmployeeId",
						column: x => x.EmployeeId,
						principalTable: "Employee",
						principalColumn: "Id",
						onDelete: ReferentialAction.NoAction);
				});

			migrationBuilder.CreateTable(
				name: "Invoices",
				columns: table => new
				{
					Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
					Date = table.Column<DateTime>(type: "datetime2", nullable: false),
					Type = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
					TotalAmount = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
					CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
					SupplierId = table.Column<string>(type: "nvarchar(450)", nullable: false),
					CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Invoices", x => x.Id);
					table.ForeignKey(
						name: "FK_Invoices_AspNetUsers_CreatedById",
						column: x => x.CreatedById,
						principalTable: "AspNetUsers",
						principalColumn: "Id",
						onDelete: ReferentialAction.NoAction);
					table.ForeignKey(
						name: "FK_Invoices_Customers_CustomerId",
						column: x => x.CustomerId,
						principalTable: "Customers",
						principalColumn: "Id",
						onDelete: ReferentialAction.NoAction);
					table.ForeignKey(
						name: "FK_Invoices_Suppliers_SupplierId",
						column: x => x.SupplierId,
						principalTable: "Suppliers",
						principalColumn: "Id",
						onDelete: ReferentialAction.NoAction);
				});

			migrationBuilder.CreateTable(
				name: "Payments",
				columns: table => new
				{
					Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
					Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
					Date = table.Column<DateTime>(type: "datetime2", nullable: false),
					Notes = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
					SupplierId = table.Column<string>(type: "nvarchar(450)", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Payments", x => x.Id);
					table.ForeignKey(
						name: "FK_Payments_Suppliers_SupplierId",
						column: x => x.SupplierId,
						principalTable: "Suppliers",
						principalColumn: "Id",
						onDelete: ReferentialAction.NoAction);
				});

			migrationBuilder.CreateTable(
				name: "Products",
				columns: table => new
				{
					Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
					Name = table.Column<string>(type: "nvarchar(200)", nullable: false),
					Code = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
					Quantity = table.Column<int>(type: "int", nullable: false),
					ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
					Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
					BatchNumber = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
					CategoryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
					WarehouseId = table.Column<string>(type: "nvarchar(450)", nullable: false),
					ProductUnitId = table.Column<string>(type: "nvarchar(450)", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Products", x => x.Id);
					table.ForeignKey(
						name: "FK_Products_Categories_CategoryId",
						column: x => x.CategoryId,
						principalTable: "Categories",
						principalColumn: "Id",
						onDelete: ReferentialAction.NoAction);
					table.ForeignKey(
						name: "FK_Products_Units_ProductUnitId",
						column: x => x.ProductUnitId,
						principalTable: "Units",
						principalColumn: "Id");
					table.ForeignKey(
						name: "FK_Products_Warehouses_WarehouseId",
						column: x => x.WarehouseId,
						principalTable: "Warehouses",
						principalColumn: "Id",
						onDelete: ReferentialAction.NoAction);
				});

			migrationBuilder.CreateTable(
				name: "InventoryTransactions",
				columns: table => new
				{
					Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
					Date = table.Column<DateTime>(type: "datetime2", nullable: false),
					Type = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
					Quantity = table.Column<int>(type: "int", nullable: false),
					ProductId = table.Column<string>(type: "nvarchar(450)", nullable: false),
					CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: false),
					WarehouseId = table.Column<string>(type: "nvarchar(450)", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_InventoryTransactions", x => x.Id);
					table.ForeignKey(
						name: "FK_InventoryTransactions_AspNetUsers_CreatedById",
						column: x => x.CreatedById,
						principalTable: "AspNetUsers",
						principalColumn: "Id",
						onDelete: ReferentialAction.NoAction);
					table.ForeignKey(
						name: "FK_InventoryTransactions_Products_ProductId",
						column: x => x.ProductId,
						principalTable: "Products",
						principalColumn: "Id",
						onDelete: ReferentialAction.NoAction);
					table.ForeignKey(
						name: "FK_InventoryTransactions_Warehouses_WarehouseId",
						column: x => x.WarehouseId,
						principalTable: "Warehouses",
						principalColumn: "Id",
						onDelete: ReferentialAction.NoAction);
				});

			migrationBuilder.CreateIndex(
				name: "RoleNameIndex",
				table: "AspNetRoles",
				column: "NormalizedName",
				unique: true,
				filter: "[NormalizedName] IS NOT NULL");

			migrationBuilder.CreateIndex(
				name: "IX_AspNetUserRoles_RoleId",
				table: "AspNetUserRoles",
				column: "RoleId");

			migrationBuilder.CreateIndex(
				name: "IX_AspNetUserRoles_UserId1",
				table: "AspNetUserRoles",
				column: "UserId1");

			migrationBuilder.CreateIndex(
				name: "IX_InventoryTransactions_CreatedById",
				table: "InventoryTransactions",
				column: "CreatedById");

			migrationBuilder.CreateIndex(
				name: "IX_InventoryTransactions_ProductId",
				table: "InventoryTransactions",
				column: "ProductId");

			migrationBuilder.CreateIndex(
				name: "IX_InventoryTransactions_WarehouseId",
				table: "InventoryTransactions",
				column: "WarehouseId");

			migrationBuilder.CreateIndex(
				name: "IX_Invoices_CreatedById",
				table: "Invoices",
				column: "CreatedById");

			migrationBuilder.CreateIndex(
				name: "IX_Invoices_CustomerId",
				table: "Invoices",
				column: "CustomerId");

			migrationBuilder.CreateIndex(
				name: "IX_Invoices_SupplierId",
				table: "Invoices",
				column: "SupplierId");

			migrationBuilder.CreateIndex(
				name: "IX_Notifications_UserId",
				table: "Notifications",
				column: "UserId");

			migrationBuilder.CreateIndex(
				name: "IX_Payments_SupplierId",
				table: "Payments",
				column: "SupplierId");

			migrationBuilder.CreateIndex(
				name: "IX_Payrolls_EmployeeId",
				table: "Payrolls",
				column: "EmployeeId");

			migrationBuilder.CreateIndex(
				name: "IX_Products_CategoryId",
				table: "Products",
				column: "CategoryId");

			migrationBuilder.CreateIndex(
				name: "IX_Products_ProductUnitId",
				table: "Products",
				column: "ProductUnitId");

			migrationBuilder.CreateIndex(
				name: "IX_Products_WarehouseId",
				table: "Products",
				column: "WarehouseId");

			migrationBuilder.CreateIndex(
				name: "IX_Receipts_CustomerId",
				table: "Receipts",
				column: "CustomerId");

			migrationBuilder.CreateIndex(
				name: "IX_RefreshTokens_UserId",
				table: "RefreshTokens",
				column: "UserId",
				unique: true);

			migrationBuilder.CreateIndex(
				name: "IX_Units_UnitId",
				table: "Units",
				column: "UnitId");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "AspNetUserRoles");

			migrationBuilder.DropTable(
				name: "InventoryTransactions");

			migrationBuilder.DropTable(
				name: "Invoices");

			migrationBuilder.DropTable(
				name: "Notifications");

			migrationBuilder.DropTable(
				name: "Payments");

			migrationBuilder.DropTable(
				name: "Payrolls");

			migrationBuilder.DropTable(
				name: "Receipts");

			migrationBuilder.DropTable(
				name: "RefreshTokens");

			migrationBuilder.DropTable(
				name: "AspNetRoles");

			migrationBuilder.DropTable(
				name: "Products");

			migrationBuilder.DropTable(
				name: "Suppliers");

			migrationBuilder.DropTable(
				name: "Employee");

			migrationBuilder.DropTable(
				name: "Customers");

			migrationBuilder.DropTable(
				name: "AspNetUsers");

			migrationBuilder.DropTable(
				name: "Categories");

			migrationBuilder.DropTable(
				name: "Units");

			migrationBuilder.DropTable(
				name: "Warehouses");
		}
	}
}

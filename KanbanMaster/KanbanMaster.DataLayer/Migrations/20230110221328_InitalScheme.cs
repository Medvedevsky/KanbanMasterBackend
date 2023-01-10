using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KanbanMaster.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class InitalScheme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KanbanBoard",
                columns: table => new
                {
                    KanbanBoardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KanbanBoard", x => x.KanbanBoardId);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "KanbanColumn",
                columns: table => new
                {
                    KanbanColumnId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KanbanBoardId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KanbanColumn", x => x.KanbanColumnId);
                    table.ForeignKey(
                        name: "FK_KanbanColumn_KanbanBoard_KanbanBoardId",
                        column: x => x.KanbanBoardId,
                        principalTable: "KanbanBoard",
                        principalColumn: "KanbanBoardId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_User_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KanbanCard",
                columns: table => new
                {
                    KanbanCardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KanbanColumnId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KanbanCard", x => x.KanbanCardId);
                    table.ForeignKey(
                        name: "FK_KanbanCard_KanbanColumn_KanbanColumnId",
                        column: x => x.KanbanColumnId,
                        principalTable: "KanbanColumn",
                        principalColumn: "KanbanColumnId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KanbanUser",
                columns: table => new
                {
                    KanbanUserId = table.Column<int>(type: "int", nullable: false),
                    Nickname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserForeignKeyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KanbanUser", x => x.KanbanUserId);
                    table.ForeignKey(
                        name: "FK_KanbanUser_User_UserForeignKeyId",
                        column: x => x.UserForeignKeyId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CardFile",
                columns: table => new
                {
                    CardFileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KanbanCardId = table.Column<int>(type: "int", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardFile", x => x.CardFileId);
                    table.ForeignKey(
                        name: "FK_CardFile_KanbanCard_KanbanCardId",
                        column: x => x.KanbanCardId,
                        principalTable: "KanbanCard",
                        principalColumn: "KanbanCardId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CardFile_KanbanCardId",
                table: "CardFile",
                column: "KanbanCardId");

            migrationBuilder.CreateIndex(
                name: "IX_KanbanCard_KanbanColumnId",
                table: "KanbanCard",
                column: "KanbanColumnId");

            migrationBuilder.CreateIndex(
                name: "IX_KanbanColumn_KanbanBoardId",
                table: "KanbanColumn",
                column: "KanbanBoardId");

            migrationBuilder.CreateIndex(
                name: "IX_KanbanUser_UserForeignKeyId",
                table: "KanbanUser",
                column: "UserForeignKeyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleId",
                table: "User",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardFile");

            migrationBuilder.DropTable(
                name: "KanbanUser");

            migrationBuilder.DropTable(
                name: "KanbanCard");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "KanbanColumn");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "KanbanBoard");
        }
    }
}

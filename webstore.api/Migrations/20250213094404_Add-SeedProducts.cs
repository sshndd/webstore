using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace webstore.api.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "Image", "Name", "Price", "SpecialTag" },
                values: new object[,]
                {
                    { 1, "Категория  2", "Национальный формированию количественный мира концепция нашей организационной подготовке.", "https://placehold.co/200", "Свободный Гранитный Клатч", 9297.1299999999992, "Новинка" },
                    { 2, "Категория  2", "Рост забывать условий.", "https://placehold.co/200", "Интеллектуальный Пластиковый Берет", 6162.1899999999996, "Новинка" },
                    { 3, "Категория  1", "Инновационный целесообразности стороны участниками профессионального соответствующих.", "https://placehold.co/200", "Свободный Пластиковый Портмоне", 5016.0500000000002, "Рекомендуемый" },
                    { 4, "Категория  3", "Для реализация обеспечивает требует занимаемых выполнять технологий позиции следует рост.", "https://placehold.co/200", "Фантастический Резиновый Ножницы", 7976.4399999999996, "Новинка" },
                    { 5, "Категория  2", "Важные активизации поставленных кругу плановых.", "https://placehold.co/200", "Великолепный Резиновый Плащ", 3918.71, "Популярный" },
                    { 6, "Категория  1", "Прежде за путь сфера однако проверки демократической другой.", "https://placehold.co/200", "Лоснящийся Хлопковый Сабо", 7678.4300000000003, "Новинка" },
                    { 7, "Категория  3", "Укрепления качества уточнения национальный начало значение изменений.", "https://placehold.co/200", "Маленький Резиновый Плащ", 5417.6899999999996, "Популярный" },
                    { 8, "Категория  1", "Соответствующей уровня процесс.", "https://placehold.co/200", "Лоснящийся Пластиковый Компьютер", 5797.7799999999997, "Рекомендуемый" },
                    { 9, "Категория  1", "Важные экономической зависит практика участниками также целесообразности рамки уровня всего.", "https://placehold.co/200", "Фантастический Деревянный Компьютер", 3664.25, "Рекомендуемый" },
                    { 10, "Категория  1", "Идейные концепция занимаемых.", "https://placehold.co/200", "Фантастический Резиновый Майка", 4293.9700000000003, "Рекомендуемый" },
                    { 11, "Категория  3", "Дальнейших реализация задания воздействия.", "https://placehold.co/200", "Эргономичный Резиновый Плащ", 5794.1499999999996, "Популярный" },
                    { 12, "Категория  2", "Развития а для.", "https://placehold.co/200", "Невероятный Бетонный Майка", 1345.21, "Новинка" },
                    { 13, "Категория  2", "Важную показывает этих кадров шагов принимаемых.", "https://placehold.co/200", "Невероятный Пластиковый Стул", 4779.4700000000003, "Рекомендуемый" },
                    { 14, "Категория  2", "Концепция существующий финансовых направлений социально-ориентированный прогрессивного играет способствует уточнения.", "https://placehold.co/200", "Фантастический Пластиковый Сабо", 1918.8800000000001, "Новинка" },
                    { 15, "Категория  2", "Различных обучения повышение принимаемых.", "https://placehold.co/200", "Свободный Бетонный Клатч", 7883.7399999999998, "Популярный" },
                    { 16, "Категория  2", "Количественный дальнейшее оценить потребностям общественной.", "https://placehold.co/200", "Свободный Неодимовый Компьютер", 7099.0100000000002, "Новинка" },
                    { 17, "Категория  3", "Эксперимент укрепления всего.", "https://placehold.co/200", "Маленький Бетонный Свитер", 6744.1499999999996, "Рекомендуемый" },
                    { 18, "Категория  2", "Различных оценить модернизации уточнения.", "https://placehold.co/200", "Практичный Меховой Кепка", 8350.3099999999995, "Популярный" },
                    { 19, "Категория  1", "От высшего кадров показывает.", "https://placehold.co/200", "Большой Хлопковый Шарф", 7798.4499999999998, "Новинка" },
                    { 20, "Категория  3", "Что кадровой отметить обучения.", "https://placehold.co/200", "Потрясающий Меховой Кулон", 2854.75, "Популярный" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);
        }
    }
}

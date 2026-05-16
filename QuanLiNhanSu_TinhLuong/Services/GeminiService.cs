using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace QuanLiNhanSu_TinhLuong.Services
{
    public class GeminiService
    {
        public async Task<string> HoiDapGemini(string cauHoi)
        {
            // Thay mã API Key của bạn vào đây (như trong hình của bạn đã có)
            string apiKey = "AIzaSyCvbQwvQGWJkT7BVFDi4KqLJTiw8XHEVEQw";
            string url = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-1.5-flash:generateContent?key={apiKey}";

            using (var client = new HttpClient())
            {
                // Định dạng chuỗi JSON gửi đi
                var requestBody = new
                {
                    contents = new[] { new { parts = new[] { new { text = cauHoi } } } }
                };

                string jsonBody = JsonSerializer.Serialize(requestBody);
                var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                // Gọi API
                var response = await client.PostAsync(url, content);
                string responseString = await response.Content.ReadAsStringAsync();

                // Trích xuất kết quả
                return responseString;
            }
        }
    }
}
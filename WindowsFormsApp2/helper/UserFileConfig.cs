using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace WindowsFormsApp2.helper
{
    public class UserFileConfig
    {
        private static UserFileConfig instance;
        private readonly string baseFolder;

        // 기본 경로 설정
        private UserFileConfig()
        {
            baseFolder = ConfigurationManager.AppSettings["UserInfoPath"];

            if (string.IsNullOrEmpty(baseFolder))
            {
                Debug.WriteLine("UserInfoPath가 설정되지 않았습니다.");

                string projectName = Assembly.GetEntryAssembly().GetName().Name;
                string className = nameof(User);

                baseFolder = $"D:\\Nas\\{projectName}\\{className}";
            }

            if (!Directory.Exists(baseFolder))
            {
                Directory.CreateDirectory(baseFolder);
            }
        }

        public static UserFileConfig Instance
        {
            get
            {
                if (instance == null)
                    instance = new UserFileConfig();
                return instance;
            }
        }

        // 저장할 경로 설정
        public string GetUserImagePath(int id, string fileName)
        {
            string folder = Path.Combine(baseFolder, id.ToString());

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            return Path.Combine(folder, fileName);
        }

        // 이미지 저장
        public string SaveUserImage(Image image, int id, string fileName)
        {
            string savePath = GetUserImagePath(id, fileName);

            using (var bmp = new Bitmap(image))
            {
                bmp.Save(savePath);
            }

            return savePath;
        }

        // 사원 이미지 삭제
        public void DeleteUserImage(int id)
        {
            string targetFolder = Path.Combine(baseFolder, id.ToString());

            if (Directory.Exists(targetFolder))
            {
                try
                {
                    Directory.Delete(targetFolder, true);
                    Debug.WriteLine("폴더가 삭제되었습니다.");
                }
                catch (IOException ioEx)
                {
                    Debug.WriteLine("폴더 삭제 중 오류 발생: " + ioEx.Message);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("폴더 삭제 중 오류 발생: " + ex.Message);
                }
            }
        }
    }
}

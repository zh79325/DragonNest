// ���� ifdef ���Ǵ���ʹ�� DLL �������򵥵�
// ��ı�׼�������� DLL �е������ļ��������������϶���� DNTHANDLER_EXPORTS
// ���ű���ġ���ʹ�ô� DLL ��
// �κ�������Ŀ�ϲ�Ӧ����˷��š�������Դ�ļ��а������ļ����κ�������Ŀ���Ὣ
// DNTHANDLER_API ������Ϊ�Ǵ� DLL ����ģ����� DLL ���ô˺궨���
// ������Ϊ�Ǳ������ġ�
#ifdef DNTHANDLER_EXPORTS
#define DNTHANDLER_API  __declspec(dllexport)
#else
#define DNTHANDLER_API __declspec(dllimport)
#endif
 

 
extern "C"  DNTHANDLER_API void LoadDntFile(char *filename);
extern "C"  DNTHANDLER_API void SaveDntFile(char *filename);
extern "C"  DNTHANDLER_API int GetRow();
extern "C"  DNTHANDLER_API int GetCol();
extern "C"  DNTHANDLER_API char *GetTitle(int col);
extern "C"  DNTHANDLER_API char *GetValue(int row, int col);
extern "C"  DNTHANDLER_API void SetValue(int row, int col, char *value);
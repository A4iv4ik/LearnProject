using UnityEditor;
using UnityEngine;

public class Cuberedactor : EditorWindow
{
    public Color myColor;         // Градиент цвета
    public MeshRenderer GO;      // Ссылка на рендер объекта
    public Material NewMat;
    [MenuItem("Всякая всячина/Редактор кубов")]
    public static void ShowWindow()
    {
        GetWindow(typeof(Cuberedactor),false,"Редактор кубов");
    }
    void OnGUI()
    {
        GO = EditorGUILayout.ObjectField("Меш объекта",GO,typeof(MeshRenderer),true) as MeshRenderer;
        NewMat = EditorGUILayout.ObjectField("Материал объекта",NewMat,typeof(Material),true) as Material;
        if (GO)
        {
        myColor = RGBSlider(new Rect(10, 30, 200, 20), myColor);  // Отрисовка пользовательского набора слайдеров для получения градиента цвета
        GO.sharedMaterial.color = myColor; // Покраска объекта
        }
        else
        {
            if (GUILayout.Button("Создать"))
            {
                GameObject main = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                MeshRenderer GORenderer = main.GetComponent<MeshRenderer>();
                GORenderer.sharedMaterial = NewMat;
                main.transform.position = Vector3.zero;
                GO = GORenderer;
            }
        }
    }

    // Отрисовка пользовательского слайдера
    float LabelSlider(Rect screenRect, float sliderValue, float sliderMaxValue, string labelText) // ДЗ добавить MinValue
    {
        // создаём прямоугольник с координатами в пространстве и заданой шириной и высотой 
        Rect labelRect = new Rect(screenRect.x, screenRect.y, screenRect.width / 2, screenRect.height);

        GUI.Label(labelRect, labelText);   // создаём Label на экране

        Rect sliderRect = new Rect(screenRect.x + screenRect.width / 2, screenRect.y, screenRect.width / 2, screenRect.height); // Задаём размеры слайдера
        sliderValue = GUI.HorizontalSlider(sliderRect, sliderValue, 0.0f, sliderMaxValue); // Вырисовываем слайдер и считываем его параметр
        return sliderValue; // Возвращаем значение слайдера
    }

    // Отрисовка тройной слайдер группы, каждый слайдер отвечает за свой цвет
    Color RGBSlider(Rect screenRect, Color rgb)
    {
        // Используя пользовательский слайдер, создаём его
        rgb.r = LabelSlider(screenRect, rgb.r, 1.0f, "Red");

        // делаем промежуток
        screenRect.y += 20;
        rgb.g = LabelSlider(screenRect, rgb.g, 1.0f, "Green");

        screenRect.y += 20;
        rgb.b = LabelSlider(screenRect, rgb.b, 1.0f, "Blue");

        screenRect.y += 20;
        rgb.a = LabelSlider(screenRect, rgb.a, 1.0f, "alpha");

        return rgb; // возвращаем цвет
    }
}

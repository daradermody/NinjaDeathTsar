using UnityEngine;

public class OrthographicResizer : MonoBehaviour {
    public Camera orthographicCamera;
    public int pixelsPerUnit;
    public int minOrthographicSize = 6;

    int verticalScreenSize = 0;
    int currentScreenSize;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        currentScreenSize = Screen.height;
        if (verticalScreenSize != currentScreenSize) {
            verticalScreenSize = currentScreenSize;

            int monitorPixelsPerSpritePixel = (int)((float)verticalScreenSize / minOrthographicSize / 2 / pixelsPerUnit);
            float orthographicSize = (float)verticalScreenSize / (pixelsPerUnit * monitorPixelsPerSpritePixel) / 2;
            orthographicCamera.orthographicSize = orthographicSize;
        }
		
	}
}

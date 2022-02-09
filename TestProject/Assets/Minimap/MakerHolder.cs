using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakerHolder : MonoBehaviour
{
    public GameObject makerPrefab;
    public GameObject playerObject;
    public RectTransform makerParentRectTransform;
    public Camera minimapCamera;

    private List<(ObjectivePosition objectivePosition, RectTransform makerRectTransform)> currentObjectives;
    // Start is called before the first frame update
    void Start()
    {
        currentObjectives = new List<(ObjectivePosition objectivePosition, RectTransform makerRectTransform)>();
        //playerObject = NetworkingClient.Player;
    }

    // Update is called once per frame
    void Update()
    {
        foreach((ObjectivePosition objectivePosition, RectTransform makerRectTransform) maker in currentObjectives)
        {
            Vector3 offset = Vector3.ClampMagnitude(maker.objectivePosition.transform.position = playerObject.transform.position, minimapCamera.orthographicSize);
            offset = offset / minimapCamera.orthographicSize * (makerParentRectTransform.rect.width / 2f);
            maker.makerRectTransform.anchoredPosition = new Vector2(offset.x, offset.z);
        }
    }
    public void AddObjectiveMaker(ObjectivePosition sender)
    {
        RectTransform rectTransform = Instantiate(makerPrefab, makerParentRectTransform).GetComponent<RectTransform>();
        currentObjectives.Add((sender, rectTransform));
    }

    public void RemoveObjectiveMaker(ObjectivePosition sender)
    {
        if (!currentObjectives.Exists(objective => objective.objectivePosition == sender))
            return;
        (ObjectivePosition pos, RectTransform rectTrans) foundObj = currentObjectives.Find(objective => objective.objectivePosition == sender);
        Destroy(foundObj.rectTrans.gameObject);
        currentObjectives.Remove(foundObj);
    }
}

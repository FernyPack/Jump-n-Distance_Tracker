using UnityEngine;
using TMPro;

public class DistanceDisplay : MonoBehaviour
{
    public PlayerMovement player;
    private TMP_Text text;

    void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    void Update()
    {
        Vector3 current = player.transform.position;
        Vector3 initial = player.initialPosition;

        float displacement = Vector3.Distance(initial, current);
        float total = player.totalDistanceTravelled;

        text.text =
            "Current Position:\n" +
            "X " + current.x.ToString("F2") +
            "  Y " + current.y.ToString("F2") +
            "  Z " + current.z.ToString("F2") + "\n\n" +

            "Initial Position:\n" +
            "X " + initial.x.ToString("F2") +
            "  Y " + initial.y.ToString("F2") +
            "  Z " + initial.z.ToString("F2") + "\n\n" +

            "Distance From Initial: " + displacement.ToString("F2") + "m\n" +
            "Total Distance Travelled: " + total.ToString("F2") + "m";
    }
}

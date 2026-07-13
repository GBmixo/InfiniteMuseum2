using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class TestAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Vector3 testOffset;
    Vector3 targetSpotForAction;
    bool preparingForActionAtSpot = false;

    public List<GameObject> knownRoomZones;
    public Dictionary<string, string> timeTable = new Dictionary<string, string>
    {
        {"1:00 AM", "Sleep"},
        {"5:00 AM", "Wake Up"},
        {"6:00 AM", "Food"},
        {"7:00 AM", "Sleep"},
        {"8:00 AM", "Food"},
        {"6:00 PM", "Food"}
    };

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    string ParseTimeInfo(bool isDay, int currentHour, int currentMinute)
    {
        string amOrPm = "???";
        if(isDay)
        {
            amOrPm = "AM";
        }
        else
        {
            amOrPm = "PM";
        }
        string currentMinWithLeadingZero;
        if(currentMinute < 10)
        {
            currentMinWithLeadingZero = $"0{currentMinute}";
        }
        else
        {
            currentMinWithLeadingZero = $"{currentMinute}";
        }
        return $"{currentHour}:{currentMinWithLeadingZero} {amOrPm}";
    }

    void EvaluateTime(bool isDay, int currentHour, int currentMinute)
    {
        //time format: "1:00 PM"
        string currentTime = ParseTimeInfo(isDay, currentHour, currentMinute);
        //Debug.Log($"current time is {currentTime}");
        if(timeTable.ContainsKey(currentTime))
        {
            ScheduleLogic(timeTable[currentTime]);
        }
    }

    void ScheduleLogic(string currentScheduledEvent)
    {
        GameObject targetRoom = null;
        bool roomTargeted = false;
        bool alternateBehavior = false;
        //Vector3 lastPosition;
        if(currentScheduledEvent == "Sleep")
        {
            targetRoom = FindRoom("Bedroom1");
            RoomZoneLogic roomLogic = targetRoom.GetComponent<RoomZoneLogic>();
            GameObject targetBed = roomLogic.facilities.Find(obj => obj.name == "Bed01");
            Vector3 targetStand =  targetBed.transform.GetChild(0).transform.position;
            targetSpotForAction = targetStand;
            MoveToCoords(targetStand);
            
        }
        else if(currentScheduledEvent == "Food")
        {
            targetRoom = FindRoom("Kitchen1");
            roomTargeted = true;
        }
        else if(currentScheduledEvent == "MorningRoutine")
        {
            targetRoom = FindRoom("Bedroom1");
        }

        if(roomTargeted == true && alternateBehavior == false)
        {
            MoveToCoords(targetRoom.GetComponent<RoomZoneLogic>().GetRandomPoint());
        }
    }

    GameObject FindRoom(string roomName)
    {
        GameObject room = knownRoomZones.Find(obj => obj.name == roomName);
        return room;
    }

    void MoveToCoords(Vector3 targetDestination)
    {
        agent.destination = targetDestination;
    }

    // Update is called once per frame
    void Update()
    {
        //agent.destination = testDestination.position;
        agent.Move(testOffset);
        if(preparingForActionAtSpot && transform.position == targetSpotForAction)
        {
            Debug.Log($"Should perform action now");
        }
    }

    private void OnEnable()
    {
        TimeClock.timePass += EvaluateTime;
    }
    private void OnDisable()
    {
        
    }
}

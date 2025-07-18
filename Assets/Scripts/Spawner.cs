using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] Sectionarray;
    [SerializeField] GameObject previusSection;
    [SerializeField] byte numberOfSection;
    [SerializeField] float OffSet=10f;
    [SerializeField] float SectionLenght = 1000f;

    // Start is called before the first frame update
    void Start()
    {
        //for (int i = 0; i < numberOfSection; i++)
        //{

        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Midsection"))
        {
            if (previusSection != null)
            {
                previusSection.SetActive(false);
                
            }
            previusSection = other.transform.parent.gameObject;
            GameObject temp = ObjectPooler.currentInstance.GiveMeASection();
            temp.transform.position = new Vector3(0, other.transform.parent.position.y - 0.1f, other.transform.position.z + OffSet + SectionLenght);
            temp.transform.rotation = Quaternion.identity;
        }
    }
}

using UnityEngine;
using UnityEngine.UI;

public class FuelManager : MonoBehaviour
{
    [SerializeField] Image fuelBar;
    [SerializeField] float fuelCountDown=100f,reduceFuelAmount=1f, reduceFuelAmountAfterDash=20f;
    [SerializeField] GameObject FuelOverPanel;

    private void Awake()
    {
        FuelOverPanel.SetActive(false);
    }
    public void Fuel()
    {
        fuelCountDown -= reduceFuelAmount;

        if (fuelCountDown<0) { FuelOver(); }
        else { FuelBarUpdate(); }
    }

    public void FuelAfterDash()
    {
        fuelCountDown -= reduceFuelAmountAfterDash;
        if (fuelCountDown < 0) { FuelOver(); }
        else { FuelBarUpdate(); }
    }

    void FuelBarUpdate()
    {
        fuelBar.fillAmount = fuelCountDown/100;
    }

    void FuelOver() 
    {
        GetComponent<PlayerMovement>().enabled = false;
        FuelOverPanel.SetActive(true);
    }

    public void CollectFuel()
    {
        fuelCountDown += 15f;
        if (fuelCountDown>=100)
        {
            fuelCountDown = 100;
        }
        FuelBarUpdate();
    }
}

using UnityEngine;
using UnityEngine.UI;

public class UIDropdown : MonoBehaviour {
    [Tooltip("Add items (gameobjects) to the dropdown which has the given tag.")]
    public string populateByTag;

    Dropdown m_dropdown;

    void Awake() {
        m_dropdown = gameObject.GetComponent<Dropdown>();
        m_dropdown.ClearOptions();

        GameObject[] tag_items = GameObject.FindGameObjectsWithTag(populateByTag);
        if (populateByTag != null) {
            foreach (GameObject item in tag_items) {
                AddItemToDropdown(item.name);
            }
        }

        m_dropdown.RefreshShownValue();

        m_dropdown.onValueChanged.AddListener(delegate {
            print("Item: " + m_dropdown.options[m_dropdown.value].text + " | Id: " + m_dropdown.value);
        });
    }

    public void SelectOption(string text) {
        int option_id = 0;
        foreach (Dropdown.OptionData data in m_dropdown.options) {
            if (data.text == text) {
                m_dropdown.value = option_id;
                m_dropdown.RefreshShownValue();
            }
            option_id++;
        }
    }

    public void AddItemToDropdown(string item, bool select_on_add=false) {
        m_dropdown.options.Add(new Dropdown.OptionData(item));

        if (select_on_add) {
            SelectOption(item);
        }
    }

    public void AddItemToDropdownAndSelect(string item) {
        AddItemToDropdown(item, true);
    }
}

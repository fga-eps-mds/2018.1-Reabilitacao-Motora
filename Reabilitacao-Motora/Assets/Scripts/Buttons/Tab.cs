using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Tab : MonoBehaviour
{
    private EventSystem system;

    private void Start()
    {
        system = EventSystem.current;
    }

		/**
		 * Permite usar tab para transitar entre os input fields.
		 */
    private void Update()
    {
			Selectable current = system.currentSelectedGameObject.GetComponent<Selectable>();
			Selectable next;

        if(system.currentSelectedGameObject == null || !Input.GetKeyDown (KeyCode.Tab))
            return;

        if (current == null)
            return;

        bool up = Input.GetKey (KeyCode.LeftShift) || Input.GetKey (KeyCode.RightShift);
				if(up)
				{
					next = current.FindSelectableOnUp();
				}
				else
				{
					next = current.FindSelectableOnDown();
				}


        if(next == null)
        {
            next = current;

            Selectable pnext;
            if(up)
						{
							while((pnext = next.FindSelectableOnDown()) != null)
							{
								next = pnext;
							}
						}
						else
						{
							while((pnext = next.FindSelectableOnUp()) != null)
							{
								next = pnext;
							}
						}
				}

        InputField inputfield = next.GetComponent<InputField>();
        if(inputfield != null)
				{
					inputfield.OnPointerClick(new PointerEventData(system));
				}
        system.SetSelectedGameObject(next.gameObject);
    }
}

using System.Collections.Generic;
using UnityEngine;
public class Inventario : Singleton<Inventario>
{
    [SerializeField] private int numeroDeSlots;
    public int NumeroDeSlots => numeroDeSlots;

    [Header("Items")]
    [SerializeField] private InventarioItem[] itemsInventario;
    public InventarioItem[] ItemsInventario => itemsInventario;

    private void Start()
    {
        itemsInventario = new InventarioItem[numeroDeSlots];
    }
    public void AņadirItem(InventarioItem itemPorAņadir, int cantidad)
    {
        if (itemPorAņadir == null)
        {
            return;
        }
        List<int> indexes = VerificarExistencias(itemPorAņadir.ID);
        if (itemPorAņadir.EsAcumulable)
        {
            if (indexes.Count > 0)
            {
                for (int i = 0; i < indexes.Count; i++)
                {
                    if(itemsInventario[indexes[i]].Cantidad< itemPorAņadir.AcumulacionMax)
                    {
                        itemsInventario[indexes[i]].Cantidad += cantidad;
                        if(itemsInventario[indexes[i]].Cantidad> itemPorAņadir.AcumulacionMax)
                        {
                            int diferencia = itemsInventario[indexes[i]].Cantidad - itemPorAņadir.AcumulacionMax;
                            itemsInventario[indexes[i]].Cantidad = itemPorAņadir.AcumulacionMax;
                            AņadirItem(itemPorAņadir,diferencia);
                        }
                        InventarioUI.Instance.DibujarItemEnInventario(itemPorAņadir, itemsInventario[indexes[i]].Cantidad, indexes[i]);
                        return;
                    }
                }
            }
        }
        if (cantidad<=0)
        {
            return;
        }
        if(cantidad> itemPorAņadir.AcumulacionMax)
        {
            AņadirItemEnSlotDisponible(itemPorAņadir, itemPorAņadir.AcumulacionMax);
            cantidad -= itemPorAņadir.AcumulacionMax;
            AņadirItem(itemPorAņadir, cantidad);
        }
        else
        {
            AņadirItemEnSlotDisponible(itemPorAņadir, cantidad);
        }
    }
    private List<int> VerificarExistencias(string itemID)
    {
        List<int> indexesDelItem = new List<int>();
        for (int i = 0; i < itemsInventario.Length; i++)
        {
            if (itemsInventario[i] != null)
            {
                if (itemsInventario[i].ID == itemID)
                {
                    indexesDelItem.Add(i);
                }
            }
        }
        return indexesDelItem;
    }//fin List<>
    private void AņadirItemEnSlotDisponible(InventarioItem item, int cantidad)
    {
        for (int i = 0; i < itemsInventario.Length; i++)
        {
            if (itemsInventario[i] == null)
            {
                itemsInventario[i] = item.CopiarItem();
                itemsInventario[i].Cantidad = cantidad;
                InventarioUI.Instance.DibujarItemEnInventario(item, cantidad, i);
                return;
            }
        }
    }
}

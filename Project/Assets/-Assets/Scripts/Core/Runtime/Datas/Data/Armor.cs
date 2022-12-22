namespace Data
{
    public class Armor : Equipment // 프로그래밍에서 사용할 데이터.
    {
        private ArmorEntity armor;

        public Armor(ItemEntity item, EquipmentEntity equipment, ArmorEntity armor) : base(item, equipment)
        {
            this.armor = armor;
        }

        public ArmorType ArmorType { get => armor.type; }
    }
}

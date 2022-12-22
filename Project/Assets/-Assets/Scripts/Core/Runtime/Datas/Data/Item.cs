namespace Data
{
    public class Item // 프로그래밍에서 사용할 데이터.
    {
        private ItemEntity item;

        public Item(ItemEntity item)
        {
            this.item = item;
        }

        public string Id { get => item._id; }
        public string Name { get => item.name; }
        public ItemType ItemType { get => item.type; }
        public string Description { get => item.description; }
        public string PathMesh { get => item.path_mesh; }
        public string PathImage { get => item.path_image; }
    }
}

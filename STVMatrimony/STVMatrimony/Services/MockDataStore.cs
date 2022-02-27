using STVMatrimony.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STVMatrimony.Services
{
    public class MockDataStore : IDataStore<VwCustomerBasicInfo>
    {
        readonly List<VwCustomerBasicInfo> items;

        public MockDataStore()
        {
            items = new List<VwCustomerBasicInfo>()
            {
                new VwCustomerBasicInfo { Id = 1, Name = "Abinaya", Education="B.Arch Architect.", Age=24, Pic1="https://igimages.gumlet.io/telugu/gallery/actress/anjali/Anjali_041206_011.jpg" },
                new VwCustomerBasicInfo { Id =2, Name = "Geetha", Education="B.Com(CA)",Age=25,Pic1="https://igimages.gumlet.io/telugu/gallery/actress/anjali/Anjali_041206_011.jpg" },
                new VwCustomerBasicInfo { Id = 3, Name = "Roopa", Education="MBA Human Resource",Age=25,Pic1="https://igimages.gumlet.io/telugu/gallery/actress/anjali/Anjali_041206_011.jpg"},
                new VwCustomerBasicInfo { Id =4, Name = "Arun Kumar", Education="M.E(EEE)" ,Age=28,Pic1="https://igimages.gumlet.io/tamil/gallery/actor/karthiksiva/30042005_3.jpg"},
                new VwCustomerBasicInfo { Id = 5, Name = "Karthik Srinivasan",Education="B.Sc. Maths" ,Age=29,Pic1="https://igimages.gumlet.io/tamil/gallery/actor/karthiksiva/30042005_3.jpg"},
                new VwCustomerBasicInfo { Id = 6, Name = "Priyanka", Education="B.A. English" ,Age=25,Pic1="https://igimages.gumlet.io/telugu/gallery/actress/anjali/Anjali_041206_011.jpg"}
            };
        }

        public async Task<bool> AddItemAsync(VwCustomerBasicInfo item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(VwCustomerBasicInfo item)
        {
            var oldItem = items.Where((VwCustomerBasicInfo arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = items.Where((VwCustomerBasicInfo arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<VwCustomerBasicInfo> GetItemAsync(int id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<VwCustomerBasicInfo>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}
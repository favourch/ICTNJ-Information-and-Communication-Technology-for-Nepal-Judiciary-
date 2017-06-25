using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.LIS.ATT
{
    public class ATTPublisher
    {

        private int _PublisherID;
        public int PublisherID
        {
            get { return this._PublisherID; }
            set { this._PublisherID = value; }
        }
        private string _PublisherName;
        public string PublisherName
        {
            get { return this._PublisherName; }
            set { this._PublisherName = value; }
        }
        private string _PublisherAddress;
        public string PublisherAddress
        {
            get { return this._PublisherAddress; }
            set { this._PublisherAddress = value; }
        }
        private string _EntryBy;
        public string EntryBy
        {
            get { return this._EntryBy; }
            set { this._EntryBy = value; }
        }

        private string _EntryOn;
        public string EntryOn
        {
            get { return this._EntryOn; }
            set { this._EntryOn = value; }
        }

         public ATTPublisher()
         {
             //
             // TODO: Add constructor logic here
             //
         }
        public ATTPublisher(int id, string publisherName, string publisherAddress, string entryBy, string entryOn)
        {
            PublisherID = id;
            PublisherName = publisherName;
            PublisherAddress = publisherAddress;
            EntryBy = entryBy;
            EntryOn = entryOn;
        }
        public ATTPublisher(int id, string publisherName, string publisherAddress)
        {
            PublisherID = id;
            PublisherName = publisherName;
            PublisherAddress = publisherAddress;
        }
        public ATTPublisher(string publisherName, string publisherAddress, string entryBy)
        {
            PublisherName = publisherName;
            PublisherAddress = publisherAddress;
            EntryBy = entryBy;
        }

        public ATTPublisher(int id)
        {
            PublisherID = id;
        }
 
    }
}

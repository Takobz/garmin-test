using Dynastream.Fit;

namespace GARMIN_TEST.Helpers 
{
    public interface IFitActivityHelper 
    {
        
    }

    public class FitActivityHelper : IFitActivityHelper
    {
        private readonly Decode _decoder;
        private readonly MesgBroadcaster _messageBroadcaster;

        public FitActivityHelper() 
        {
            _decoder = new Decode();
            _messageBroadcaster = new MesgBroadcaster();

            _decoder.MesgEvent += _messageBroadcaster.OnMesg;
            _decoder.MesgDefinitionEvent += _messageBroadcaster.OnMesgDefinition;
        }

        public Stream ReadFitFileAsStream() 
        {
            using FileStream fileStream = new FileStream(@"../sample-fit-files/sample.fit", FileMode.Open, FileAccess.Read);
            byte[] bytes = new byte[fileStream.Length];
            int numberOfByteToRead = (int)fileStream.Length;
            int numberOfBytesRead = 0;
            while (numberOfByteToRead > 0)
            {
                // Read may return anything from 0 to numBytesToRead.
                int n = fileStream.Read(bytes, numBytesRead, numberOfByteToRead);

                // Break when the end of the file is reached.
                if (n == 0)
                    break;

                numberOfBytesRead += n;
                numberOfByteToRead -= n;
            }
            numberOfByteToRead = bytes.Length;

            // Write the byte array to the other FileStream.
            using (FileStream fsNew = new FileStream(pathNew,
                FileMode.Create, FileAccess.Write))
            {
                fsNew.Write(bytes, 0, numberOfByteToRead);
            }
        }
    }
}